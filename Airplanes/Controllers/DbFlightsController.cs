using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airplanes.Models;
using Microsoft.AspNetCore.Authorization;

namespace Airplanes.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class DbFlightsController : Controller
    {
        private readonly AirplanesContext _context;

        public DbFlightsController(AirplanesContext context)
        {
            _context = context;
        }
        
        // GET: DbFlights
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbFlight.Include(d => d.DbPlane).Include(d => d.DbRoute);
            return View(await AirplanesContext.ToListAsync());
        }

        // GET: DbFlights/Details/5
        public async Task<IActionResult> Details(long? id)
        {
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

            return View(dbFlight);
        }

        // GET: DbFlights/Create
        public IActionResult Create()
        {
            ViewData["DbPlaneId"] = new SelectList(_context.DbPlane, "Id", "Id");
            ViewData["DbRouteId"] = new SelectList(_context.DbRoute, "Id", "Id");
            return View();
        }

        // POST: DbFlights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RollNumber,DbRouteId,DbPlaneId,FlightTime,TimeOfTransit,FlightDuration,CreatedAt,UpdatedAt,Status")] DbFlight dbFlight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbFlight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DbPlaneId"] = new SelectList(_context.DbPlane, "Id", "Id", dbFlight.DbPlaneId);
            ViewData["DbRouteId"] = new SelectList(_context.DbRoute, "Id", "Id", dbFlight.DbRouteId);
            return View(dbFlight);
        }

        // GET: DbFlights/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbFlight = await _context.DbFlight.FindAsync(id);
            if (dbFlight == null)
            {
                return NotFound();
            }
            ViewData["DbPlaneId"] = new SelectList(_context.DbPlane, "Id", "Id", dbFlight.DbPlaneId);
            ViewData["DbRouteId"] = new SelectList(_context.DbRoute, "Id", "Id", dbFlight.DbRouteId);
            return View(dbFlight);
        }

        // POST: DbFlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,RollNumber,DbRouteId,DbPlaneId,FlightTime,TimeOfTransit,FlightDuration,CreatedAt,UpdatedAt,Status")] DbFlight dbFlight)
        {
            if (id != dbFlight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbFlight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbFlightExists(dbFlight.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DbPlaneId"] = new SelectList(_context.DbPlane, "Id", "Id", dbFlight.DbPlaneId);
            ViewData["DbRouteId"] = new SelectList(_context.DbRoute, "Id", "Id", dbFlight.DbRouteId);
            return View(dbFlight);
        }

        // GET: DbFlights/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
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

            return View(dbFlight);
        }

        // POST: DbFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbFlight = await _context.DbFlight.FindAsync(id);
            _context.DbFlight.Remove(dbFlight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbFlightExists(long id)
        {
            return _context.DbFlight.Any(e => e.Id == id);
        }
    }
}
