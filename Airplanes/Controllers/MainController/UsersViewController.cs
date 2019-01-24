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

        [AllowAnonymous]
        public async Task<IActionResult> ListFlightChoise()
        {
            ViewData["NotFound"] = "Not Found Flight";
            return View("ListFlightChoise", flights);
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
        
        
    }
}