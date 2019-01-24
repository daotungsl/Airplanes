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
    public class DbTransitsController : Controller
    {
        private readonly AirplanesContext _context;

        public DbTransitsController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbTransits
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbTransit.Include(d => d.DbAirPort).Include(d => d.DbFlight);
            return View(await AirplanesContext.ToListAsync());
        }

        // GET: DbTransits/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTransit = await _context.DbTransit
                .Include(d => d.DbAirPort)
                .Include(d => d.DbFlight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbTransit == null)
            {
                return NotFound();
            }

            return View(dbTransit);
        }

        // GET: DbTransits/Create
        public IActionResult Create()
        {
            ViewData["DbAirportId"] = new SelectList(_context.DbAirport, "Id", "Id");
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id");
            return View();
        }

        // POST: DbTransits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DbFlightId,DbAirportId,DelayTime,Note,CreatedAt,UpdatedAt")] DbTransit dbTransit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbTransit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DbAirportId"] = new SelectList(_context.DbAirport, "Id", "Id", dbTransit.DbAirportId);
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbTransit.DbFlightId);
            return View(dbTransit);
        }

        // GET: DbTransits/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTransit = await _context.DbTransit.FindAsync(id);
            if (dbTransit == null)
            {
                return NotFound();
            }
            ViewData["DbAirportId"] = new SelectList(_context.DbAirport, "Id", "Id", dbTransit.DbAirportId);
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbTransit.DbFlightId);
            return View(dbTransit);
        }

        // POST: DbTransits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DbFlightId,DbAirportId,DelayTime,Note,CreatedAt,UpdatedAt")] DbTransit dbTransit)
        {
            if (id != dbTransit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbTransit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbTransitExists(dbTransit.Id))
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
            ViewData["DbAirportId"] = new SelectList(_context.DbAirport, "Id", "Id", dbTransit.DbAirportId);
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbTransit.DbFlightId);
            return View(dbTransit);
        }

        // GET: DbTransits/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTransit = await _context.DbTransit
                .Include(d => d.DbAirPort)
                .Include(d => d.DbFlight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbTransit == null)
            {
                return NotFound();
            }

            return View(dbTransit);
        }

        // POST: DbTransits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbTransit = await _context.DbTransit.FindAsync(id);
            _context.DbTransit.Remove(dbTransit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbTransitExists(long id)
        {
            return _context.DbTransit.Any(e => e.Id == id);
        }
    }
}
