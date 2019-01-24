using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Airplanes.Models;
using Airplanes.Models.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserGender = Airplanes.Models.Custom.UserGender;

namespace Airplanes.Controllers.MainController
{
    public class UsersViewController : Controller
    {
        private readonly AirplanesContext _context;
        private readonly UserManager<AirplanesUser> _userManager;
        private readonly SignInManager<AirplanesUser> _signInManager;
        private List<DbFlight> flights = new List<DbFlight>();
        public UsersViewController(AirplanesContext context, UserManager<AirplanesUser> userManager,
            SignInManager<AirplanesUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public SelectInformation selectInformation { get; set; }
        public PickUp pickUp { get; set; }
        public class DetailFlight
        {
            public DbFlight DbFlight { get; set; }
            public List<DbAvailableSeat> DbAvailableSeats { get; set; }
        }
        public string ReturnUrl { get; set; }
        public class SelectInformation
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "From Airport")]
            public string FromAirport { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "To Airport")]
            public string ToAirport { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime Date { get; set; }
        }

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

        [AllowAnonymous]
        public IActionResult ChoiseRoute()
        {
            //ViewData["FromAirport"] = new SelectList(_context.DbRoute, "FromAirport", "FromAirport");
            //ViewData["ToAirport"] = new SelectList(_context.DbRoute, "ToAirport", "ToAirport");

            ViewData["FromAirport"] = new SelectList(_context.DbCity, "Name", "Name");
            ViewData["ToAirport"] = new SelectList(_context.DbCity, "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChoiseRoute([Bind("FromAirport, ToAirport, Date")] SelectInformation selectInformation)
        {

            if (ModelState.IsValid)
            {
                var city1 = _context.DbCity.FirstOrDefault(c => c.Name == selectInformation.FromAirport);
                var city2 = _context.DbCity.FirstOrDefault(c => c.Name == selectInformation.ToAirport);
                var date = selectInformation.Date;
                if (selectInformation.FromAirport == selectInformation.ToAirport)
                {
                    ViewBag.Match = "Can't match";
                    return View();
                }
                if (city2 == null)
                {
                    List<DbRoute> list = await _context.DbRoute.Where(r => r.FromAirport == city1.Code).ToListAsync();
                    
                    if (FlightExists(date))
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            var flight = _context.DbFlight.FirstOrDefault(f => f.DbRouteId == list[i].Id && f.FlightTime.Date == date);
                            if (flight != null)
                            {
                                flights.Add(flight);
                            }
                        }

                        if (flights.Count == 0)
                        {
                            ViewBag.Data = "Not Found";
                            return View("ListFlightChoise", flights);
                        }
                        return View("ListFlightChoise", flights);
                    }
                    else
                    {
                        foreach (var item in list)
                        {
                            var flight = _context.DbFlight.FirstOrDefault(f => f.DbRouteId == item.Id);
                            if (flight != null)
                            {
                                flights.Add(flight);
                            }
                        }
                        if (flights.Count == 0)
                        {
                            ViewBag.Data = "Not Found";
                            return View("ListFlightChoise", flights);
                        }
                        return View("ListFlightChoise", flights);
                    }
                }
                else
                {
                    var route = _context.DbRoute.FirstOrDefault(r => r.FromAirport == city1.Code && r.ToAirport == city2.Code);
                    if (FlightExists(date))
                    {
                        if (route == null)
                        {
                            ViewBag.Error = "Can't Found";
                            Debug.WriteLine("Route null");
                            return View("ListFlightChoise", flights);
                        }
                        flights =
                            await _context.DbFlight.Where(f => f.DbRouteId == route.Id && f.FlightTime.Date == date).ToListAsync();
                        if (flights.Count == 0)
                        {
                            ViewBag.Data = "Not Found";
                            return View("ListFlightChoise", flights);
                        }

                        return View("ListFlightChoise", flights);
                    }
                    else
                    {
                        flights = await _context.DbFlight.Where(f => f.DbRouteId == route.Id).ToListAsync();
                        if (flights.Count == 0)
                        {
                            ViewBag.Data = "Not Found";
                            return View("ListFlightChoise", flights);
                        }
                        return View("ListFlightChoise", flights);
                    }
                    
                }

            }
            //ViewData["DbCityId"] = new SelectList(_context.DbCity, "Id", "Id", dbAirport.DbCityId);
            //ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id", dbAirport.CountryId);
            return View();
        }

        public async Task<IActionResult> ListFlightChoise()
        {
            ViewData["NotFound"] = "Not Found Flight";
            return View("ListFlightChoise");
        }

        [AllowAnonymous]
        public async Task<IActionResult> DetailsFlight(long? id)
        {
            ViewData["flightId"] = id;
            if (id == null)
            {
                return NotFound();
            }
            var dbFlight = await _context.DbFlight
                .Include(d => d.DbPlane)
                .Include(d => d.DbRoute)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbFlight == null)
            {
                return NotFound();
            }

            List<DbAvailableSeat> dbSeat = await _context.DbAvailableSeat
                .Include(s => s.DbFlight)
                .Include(s => s.DbTicketClass).Where(m => m.DbFlightId == dbFlight.Id).ToListAsync();
            DetailFlight dtf = new DetailFlight
            {
                DbFlight = dbFlight,
                DbAvailableSeats = dbSeat
            };

            if (dbSeat.Count == 0)
            {
                ViewBag.Seat = "SORRY !";
                ViewBag.Seat2 = "Not Have Information Ticket In This Flight!";
                return View("DetailsFlight", dtf);
            }
            

            return View("DetailsFlight", dtf);
        }

        private bool FlightExists(DateTime date)
        {
            return _context.DbFlight.Any(e => e.FlightTime.Date == date);
        }
        
        [HttpGet]
        [Authorize(Roles = "User, Admin, Manager")]
        public async Task<IActionResult> PickUpTicket(long flightId, long orderId)
        {
            ViewData["flightId"] = flightId;
            ViewData["OrderId"] = orderId;
            ViewData["TicketsClass"] = new SelectList(_context.DbTicketClass, "TicketClassName", "TicketClassName");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PickUpTicket([Bind("FlightId, OrderId, FullName, Gender, Phone, Birthday, TicketClassName")] PickUp pickUp)
        {
            if (ModelState.IsValid)
            {
                //if (_signInManager.IsSignedIn(User))
                //{
                    
                //}
                DbPassenger passenger = new DbPassenger
                {
                    UId = _userManager.GetUserId(User),
                    FullName = pickUp.FullName,
                    Gender = pickUp.Gender,
                    Phone = pickUp.Phone,
                    Birthday = pickUp.Birthday,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Add(passenger);
                _context.SaveChanges();

                //var a = OrderExists(DateTime.Today, passenger.Id);
                //if (OrderExists(DateTime.Today, passenger.Id))
                //{

                //}
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
                _context.SaveChanges();

                AirplanesUser user = _userManager.Users.FirstOrDefault(s => s.Id == passenger.UId);

                user.RewardPoints += ticketClass.Points;

                await _userManager.UpdateAsync(user);
                return Redirect("/");
            }
            return View();
        }

        private bool OrderExists(DateTime date, long id)
        {
            return _context.DbOrder.Any(e => e.CreatedAt.Date == date && e.Id == id);
        }
    }
}