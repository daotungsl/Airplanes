using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airplanes.Models;
using Airplanes.Models.Custom;
using Airplanes.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airplanes.Controllers.MainController
{
    public class HistoryController : Controller
    {
        private readonly AirplanesContext _context;
        private readonly UserManager<AirplanesUser> _userManager;
        private readonly SignInManager<AirplanesUser> _signInManager;
        private List<DbFlight> flights = new List<DbFlight>();
        MailVerify mv = new MailVerify();
        public HistoryController(AirplanesContext context, UserManager<AirplanesUser> userManager,
            SignInManager<AirplanesUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public History history { get; set; }

        public class History
        {
            public string UId { get; set; }
            public List<DbOrder> DbOrders { get; set; }
            public DbTicket DbTicket { get; set; }
            public DbTicketClass DbTicketClass { get; set; }
        }
        private List<DbOrder> Orders;
        public async Task<IActionResult> HistoryOrder(string UId)
        {
            ViewData["UId1"] = UId;
            if (UId != null)
            {
                Orders = await _context.DbOrder.Where(o => o.UId == UId).ToListAsync();
                return View(Orders);
            }

            return View();
        }

        public async Task<IActionResult> DetailOrder(long? id, string uId)
        {
            ViewData["OrderId"] = id;
            ViewData["UId"] = uId;
            ViewData["AId"] = uId;
            if (id == null)
            {
                return NotFound();
            }

            var dbTicket = await _context.DbTicket
                .Include(d => d.DbFlight)
                .Include(d => d.DbOrder)
                .Include(d => d.DbPassenger)
                .Include(d => d.DbTicketClass)
                .Where(m => m.DbOrderId == id).ToListAsync();
            if (dbTicket == null)
            {
                return NotFound();
            }

            return View(dbTicket);
        }

        public async Task<IActionResult> Cancel(long? id, long? oId, string uId)
        {
            if (id == null)
            {
                return NotFound();
            }

            DbTicket ticket = _context.DbTicket.FirstOrDefault(t => t.Id == id);
            ticket.Status = TicketStatus.Cancel;

            _context.DbTicket.Update(ticket);
            await _context.SaveChangesAsync();

            DbTicketClass ticketClass = _context.DbTicketClass.FirstOrDefault(c => c.Id == ticket.DbTicketClassId);
            DbOrder order = _context.DbOrder.FirstOrDefault(o => o.Id == oId);
            AirplanesUser user = _userManager.Users.FirstOrDefault(u => u.Id == uId);
            user.RewardPoints = user.RewardPoints - (ticketClass.Points * order.Quantity);
            await _userManager.UpdateAsync(user);

            var callbackUrl = Url.Page(
                "/Home/Index",
                pageHandler: null,
                values: new { userId = user.Id},
                protocol: Request.Scheme);
            var subject = "Booking Notification";
            
            string htmlBody =
                    "<html>\r\n   <head>\r\n      <style>\r\n         .banner-color {\r\n         background-color: #eb681f;\r\n         }\r\n         .title-color {\r\n         color: #0066cc;\r\n         }\r\n         .button-color {\r\n         background-color: #0066cc;\r\n         }\r\n         @media screen and (min-width: 500px) {\r\n         .banner-color {\r\n         background-color: #0066cc;\r\n         }\r\n         .title-color {\r\n         color: #eb681f;\r\n         }\r\n         .button-color {\r\n         background-color: #eb681f;\r\n         }\r\n         }\r\n      </style>\r\n   </head>\r\n   <body>\r\n      <div style=\"background-color:#ececec;padding:0;margin:0 auto;font-weight:200;width:100%!important\">\r\n         <table align=\"center\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"table-layout:fixed;font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n            <tbody>\r\n               <tr>\r\n                  <td align=\"center\">\r\n                     <center style=\"width:100%\">\r\n                        <table bgcolor=\"#FFFFFF\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"margin:0 auto;max-width:512px;font-weight:200;width:inherit;font-family:Helvetica,Arial,sans-serif\" width=\"512\">\r\n                           <tbody>\r\n                              <tr>\r\n                                 <td bgcolor=\"#F3F3F3\" width=\"100%\" style=\"background-color:#f3f3f3;padding:12px;border-bottom:1px solid #ececec\">\r\n                                    <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;width:100%!important;font-family:Helvetica,Arial,sans-serif;min-width:100%!important\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td align=\"left\" valign=\"middle\" width=\"50%\"><span style=\"margin:0;color:#4c4c4c;white-space:normal;display:inline-block;text-decoration:none;font-size:12px;line-height:20px\">EAGLE AIRLINE</span></td>\r\n                                             <td valign=\"middle\" width=\"50%\" align=\"right\" style=\"padding:0 0 0 10px\"><span style=\"margin:0;color:#4c4c4c;white-space:normal;display:inline-block;text-decoration:none;font-size:12px;line-height:20px\">" +
                    DateTime.Now +
                    "</span></td>\r\n                                             <td width=\"1\">&nbsp;</td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                              <tr>\r\n                                 <td align=\"left\">\r\n                                    <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" bgcolor=\"#8BC34A\" style=\"padding:20px 48px;color:#ffffff\" class=\"banner-color\">\r\n                                                            <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                               <tbody>\r\n                                                                  <tr>\r\n                                                                     <td align=\"center\" width=\"100%\">\r\n                                                                        <h1 style=\"padding:0;margin:0;color:#ffffff;font-weight:500;font-size:20px;line-height:24px\">EAGLE AIRLINE VERIFY EMAIL</h1>\r\n                                                                     </td>\r\n                                                                  </tr>\r\n                                                               </tbody>\r\n                                                            </table>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" style=\"padding:20px 0 10px 0\">\r\n                                                            <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                               <tbody>\r\n                                                                  <tr>\r\n                                                                     <td align=\"center\" width=\"100%\" style=\"padding: 0 15px;text-align: justify;color: rgb(76, 76, 76);font-size: 12px;line-height: 18px;\">\r\n                                                                        <h3 style=\"font-weight: 600; padding: 0px; margin: 0px; font-size: 16px; line-height: 24px; text-align: center;\" class=\"title-color\">Hi " + user.FullName +
                    "</h3>\r\n                                                                        <p style=\"margin: 20px 0 30px 0;font-size: 15px;text-align: center;\">Xin lỗi vé của bạn đã bị hủy !</p>\r\n                                                                        <div style=\"font-weight: 200; text-align: center; margin: 25px;\"><a style=\"padding:0.6em 1em;border-radius:600px;color:#ffffff;font-size:14px;text-decoration:none;font-weight:bold\" class=\"button-color\" href=\"" + callbackUrl + "\">Trở về trang chủ</a></div>\r\n                                                                     </td>\r\n                                                                  </tr>\r\n                                                               </tbody>\r\n                                                            </table>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                      </tr>\r\n                                                      <tr>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                              <tr>\r\n                                 <td align=\"left\">\r\n                                    <table bgcolor=\"#FFFFFF\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"padding:0 24px;color:#999999;font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                       <tbody>\r\n                                          <tr>\r\n                                             <td align=\"center\" width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" valign=\"middle\" width=\"100%\" style=\"border-top:1px solid #d9d9d9;padding:12px 0px 20px 0px;text-align:center;color:#4c4c4c;font-weight:200;font-size:12px;line-height:18px\">EAGLE AIRLINE,\r\n                                                            <br><b>The Focus Team</b>\r\n                                                         </td>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                          <tr>\r\n                                             <td align=\"center\" width=\"100%\">\r\n                                                <table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-weight:200;font-family:Helvetica,Arial,sans-serif\" width=\"100%\">\r\n                                                   <tbody>\r\n                                                      <tr>\r\n                                                         <td align=\"center\" style=\"padding:0 0 8px 0\" width=\"100%\"></td>\r\n                                                      </tr>\r\n                                                   </tbody>\r\n                                                </table>\r\n                                             </td>\r\n                                          </tr>\r\n                                       </tbody>\r\n                                    </table>\r\n                                 </td>\r\n                              </tr>\r\n                           </tbody>\r\n                        </table>\r\n                     </center>\r\n                  </td>\r\n               </tr>\r\n            </tbody>\r\n         </table>\r\n      </div>\r\n   </body>\r\n</html>";



            mv.SendMail(user.Email, user.Id, htmlBody, subject);

            return Redirect("/History/DetailOrder?id=" + oId + "&uId=" + uId);
        }
    }
}