using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Airplanes.Models;
using Airplanes.Models.Custom;
using Airplanes.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airplanes.Controllers.MainController
{
    public class PickUpTicketController : Controller
    {
        private readonly AirplanesContext _context;
        private readonly UserManager<AirplanesUser> _userManager;
        private readonly SignInManager<AirplanesUser> _signInManager;
        private List<DbFlight> flights = new List<DbFlight>();
        MailVerify mv = new MailVerify();
        public PickUpTicketController(AirplanesContext context, UserManager<AirplanesUser> userManager,
            SignInManager<AirplanesUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public PickUp pickUp { get; set; }

        public class PickUp
        {
            public long FlightId { get; set; }
            public long OrderId { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Phone]
            [Display(Name = "Phone Number")]
            public string Phone { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Birthday")]
            public DateTime Birthday { get; set; }

            public string TicketClassName { get; set; }
            public TicketStatus Status { get; set; }
        }
        [HttpGet]
        [Authorize(Roles = "User, Admin, Manager")]
        public IActionResult PickUpTicket(long flightId, long orderId)
        {
            ViewData["flightId"] = flightId;
            ViewData["OrderId"] = orderId;
            ViewData["TicketsClass"] = new SelectList(_context.DbTicketClass, "TicketClassName", "TicketClassName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PickUpTicket([Bind("FlightId, OrderId, FullName, Gender, Phone, Birthday, TicketClassName, Status")] PickUp pickUp)
        {
            if (ModelState.IsValid)
            {
                if (_signInManager.IsSignedIn(User))
                {
                    // Thêm thông tin người được ghi trên vé
                    DbPassenger passenger = new DbPassenger
                    {
                        UId = _userManager.GetUserId(User),
                        FullName = pickUp.FullName,
                        Gender = pickUp.Gender,
                        Phone = pickUp.Phone,
                        Birthday = pickUp.Birthday
                    };
                    _context.DbPassenger.Add(passenger);
                    await _context.SaveChangesAsync();

                    // Lấy ra loại vé theo tên
                    DbTicketClass ticketClass =
                        _context.DbTicketClass.FirstOrDefault(t => t.TicketClassName == pickUp.TicketClassName);


                    // Thêm thông tin vào vé
                    DbTicket ticket = new DbTicket
                    {
                        DbOrderId = pickUp.OrderId,
                        DbTicketClassId = ticketClass.Id,
                        DbFlightId = pickUp.FlightId,
                        DbPassengerId = passenger.Id,
                        Price = ticketClass.Price + 250000,
                        Status = pickUp.Status
                    };
                    _context.DbTicket.Add(ticket);
                    await _context.SaveChangesAsync();
                    
                    // Lấy ra order
                    DbOrder order = _context.DbOrder.FirstOrDefault(o => o.Id == pickUp.OrderId);

                    // Cộng điểm vào điểm tích lũy
                    AirplanesUser user = _userManager.Users.FirstOrDefault(s => s.Id == passenger.UId);
                    user.RewardPoints = user.RewardPoints + (ticketClass.Points * order.Quantity);
                    await _userManager.UpdateAsync(user);

                    // trừ số vé khả dụng
                    DbAvailableSeat availableSeat = _context.DbAvailableSeat.FirstOrDefault(s =>
                        s.DbFlightId == pickUp.FlightId && s.TicketClassId == ticketClass.Id);

                    availableSeat.RestTicket = availableSeat.RestTicket - order.Quantity;
                    _context.DbAvailableSeat.Update(availableSeat);
                    await _context.SaveChangesAsync();
                    

                    // Update tổng giá
                    order.Total = (ticket.Price * order.Quantity);
                    _context.DbOrder.Update(order);
                    await _context.SaveChangesAsync();

                    // Ghi điểm vào log
                    //DbRewardPointsLog rewardPointsLog = new DbRewardPointsLog
                    //{
                    //    UId = _userManager.GetUserId(User),
                    //    NameLog = "Cộng điểm",
                    //    Points = (ticketClass.Points * order.Quantity),
                    //    Note = "Cộng " + (ticketClass.Points * order.Quantity) + " do mua " + order.Quantity + " vé hạng " + ticketClass.TicketClassName
                    //};
                    //_context.DbRewardPointsLog.Add(rewardPointsLog);
                    //await _context.SaveChangesAsync();

                    var callbackUrl = Url.Link(
                        "/History/DetailOrder/" + order.Id + "?uId=" + user.Id,
                        //pageHandler: null,
                        values: new { userId = user.Id}
                        /*protocol: Request.Scheme*/);

                    // Gửi mail thông báo
                    var subject = "Booking Ticket Success!";

                    string htmlBody =
                    "<html>\r\n   <head>\r\n      <style>\r\n         .banner-color {\r\n         background-color: #eb681f;\r\n         }\r\n         .title-color {\r\n         color: #0066cc;\r\n         }\r\n         .button-color {\r\n         background-color: #0066cc;\r\n         }\r\n         @media screen and (min-width: 500px) {\r\n         .banner-color {\r\n         background-color: #0066cc;\r\n         }\r\n         .title-color {\r\n         color: #eb681f;\r\n         }\r\n         .button-color {\r\n         background-color: #eb681f;\r\n         }\r\n         }\r\n      </style>\r\n   </head>\r\n   <body>\r\n      <div style=\"background-color:#ececec;padding:0;margin:0 auto;font-weight:200;width:100%!important\">\r\n         <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"table-layout:fixed;font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n            <tbody>\r\n               <tr>\r\n                  <td align=\"center\">\r\n                     <center style=\"width:100%\">\r\n                        <table bgcolor=\"#FFFFFF\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:0 auto;max-width:512px;font-weight:200;width:inherit;font-family:Helvetica,Arial,sans-serif\" width=\"512\">\r\n                           <tbody>\r\n                              <tr>\r\n                                 <td bgcolor=\"#F3F3F3\" width=\"100%\" style=\"background-color:#f3f3f3;padding:12px;border-bottom:1px solid #ececec\">\r\n                                    <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;width:100%!important;font-family:Helvetica,Arial,sans-serif;min-width:100%!important\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td align=\"left\" valign=\"middle\" width=\"50%\"><span style=\"margin:0;color:#4c4c4c;white-space:normal;display:inline-block;text-decoration:none;font-size:12px;line-height:20px\">EAGLE AIRLINE</span></td>\r\n                                             <td valign=\"middle\" width=\"50%\" align=\"right\" style=\"padding:0 0 0 10px\"><span style=\"margin:0;color:#4c4c4c;white-space:normal;display:inline-block;text-decoration:none;font-size:12px;line-height:20px\">" +
                    DateTime.Now +
                    "</span></td>\r\n                                             <td width=\"1\">&nbsp;</td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                              <tr>\r\n                                 <td align=\"left\">\r\n                                    <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" bgcolor=\"#8BC34A\" style=\"padding:20px 48px;color:#ffffff\" class=\"banner-color\">\r\n                                                            <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                               <tbody>\r\n                                                                  <tr>\r\n                                                                     <td align=\"center\" width=\"100%\">\r\n                                                                        <h1 style=\"padding:0;margin:0;color:#ffffff;font-weight:500;font-size:20px;line-height:24px\">EAGLE AIRLINE BOOKING NOTIFICATION</h1>\r\n                                                                     </td>\r\n                                                                  </tr>\r\n                                                               </tbody>\r\n                                                            </table>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" style=\"padding:20px 0 10px 0\">\r\n                                                            <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                               <tbody>\r\n                                                                  <tr>\r\n                                                                     <td align=\"center\" width=\"100%\" style=\"padding: 0 15px;text-align: justify;color: rgb(76, 76, 76);font-size: 12px;line-height: 18px;\">\r\n                                                                        <h3 style=\"font-weight: 600; padding: 0px; margin: 0px; font-size: 16px; line-height: 24px; text-align: center;\" class=\"title-color\">Hi " + user.FullName +
                    "</h3>\r\n                                                                        <p style=\"margin: 20px 0 30px 0;font-size: 15px;text-align: center;\">Chúc mừng bạn đã đặt vé thành công !</p>\r\n                                                                        <div style=\"font-weight: 200; text-align: center; margin: 25px;\"><a style=\"padding:0.6em 1em;border-radius:600px;color:#ffffff;font-size:14px;text-decoration:none;font-weight:bold\" class=\"button-color\" href=\"" + callbackUrl + "\">Xem thông tin</a></div>\r\n                                                                     </td>\r\n                                                                  </tr>\r\n                                                               </tbody>\r\n                                                            </table>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                              <tr>\r\n                                 <td align=\"left\">\r\n                                    <table bgcolor=\"#FFFFFF\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"padding:0 24px;color:#999999;font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td align=\"center\" width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" valign=\"middle\" width=\"100%\" style=\"border-top:1px solid #d9d9d9;padding:12px 0px 20px 0px;text-align:center;color:#4c4c4c;font-weight:200;font-size:12px;line-height:18px\">EAGLE AIRLINE,\r\n                                                            <br><b>The Focus Team</b>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                          <tr>\r\n                                             <td align=\"center\" width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" style=\"padding:0 0 8px 0\" width=\"100%\"></td>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                           </tbody>\r\n                        </table>\r\n                     </center>\r\n                  </td>\r\n               </tr>\r\n            </tbody>\r\n         </table>\r\n      </div>\r\n   </body>\r\n</html>";


                    mv.SendMail(user.Email, user.Id, htmlBody, subject);

                    return Redirect("/PickUpTicket/BookingSuccess");
                }
            }
            return View();
        }

        [Authorize(Roles = "User, Admin, Manager")]
        public IActionResult BookingSuccess()
        {
            return View();
        }

        private bool OrderExists(DateTime date, long id)
        {
            return _context.DbOrder.Any(e => e.CreatedAt.Date == date && e.Id == id);
        }
    }
    
}