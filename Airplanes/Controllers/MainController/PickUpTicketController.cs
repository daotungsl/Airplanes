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

                    DbTicketClass ticketClass =
                        _context.DbTicketClass.FirstOrDefault(t => t.TicketClassName == pickUp.TicketClassName);

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

                    AirplanesUser user = _userManager.Users.FirstOrDefault(s => s.Id == passenger.UId);
                    user.RewardPoints += ticketClass.Points;

                    await _userManager.UpdateAsync(user);
                    var subject = "Booking Notification";
                    var content = "Chuc mung ban da dat ve thanh cong!";

                    mv.SendMail(user.Email, user.Id, content, subject);

                    return Redirect("/UsersView/ChoiseRoute");
                }
            }
            return View();
        }

        private bool OrderExists(DateTime date, long id)
        {
            return _context.DbOrder.Any(e => e.CreatedAt.Date == date && e.Id == id);
        }
    }
}