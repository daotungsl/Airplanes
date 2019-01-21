using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airplanes.Models;

namespace Airplanes.Controllers
{
    public class DbAvailableSeatsController : Controller
    {
        private readonly AirplanesContext _context;

        public DbAvailableSeatsController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbAvailableSeats
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbAvailableSeat.Include(d => d.DbFlight).Include(d => d.DbTicketClass);
            return View(await AirplanesContext.ToListAsync());
        }

        // GET: DbAvailableSeats/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbAvailableSeat = await _context.DbAvailableSeat
                .Include(d => d.DbFlight)
                .Include(d => d.DbTicketClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbAvailableSeat == null)
            {
                return NotFound();
            }

            return View(dbAvailableSeat);
        }

        // GET: DbAvailableSeats/Create
        public IActionResult Create()
        {
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id");
            ViewData["TicketClassId"] = new SelectList(_context.DbTicketClass, "Id", "Id");
            return View();
        }

        // POST: DbAvailableSeats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DbFlightId,TicketClassId,Quantity,CreatedAt,UpdatedAt")] DbAvailableSeat dbAvailableSeat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbAvailableSeat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbAvailableSeat.DbFlightId);
            ViewData["TicketClassId"] = new SelectList(_context.DbTicketClass, "Id", "Id", dbAvailableSeat.TicketClassId);
            return View(dbAvailableSeat);
        }

        // GET: DbAvailableSeats/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbAvailableSeat = await _context.DbAvailableSeat.FindAsync(id);
            if (dbAvailableSeat == null)
            {
                return NotFound();
            }
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbAvailableSeat.DbFlightId);
            ViewData["TicketClassId"] = new SelectList(_context.DbTicketClass, "Id", "Id", dbAvailableSeat.TicketClassId);
            return View(dbAvailableSeat);
        }

        // POST: DbAvailableSeats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DbFlightId,TicketClassId,Quantity,CreatedAt,UpdatedAt")] DbAvailableSeat dbAvailableSeat)
        {
            if (id != dbAvailableSeat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbAvailableSeat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbAvailableSeatExists(dbAvailableSeat.Id))
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
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbAvailableSeat.DbFlightId);
            ViewData["TicketClassId"] = new SelectList(_context.DbTicketClass, "Id", "Id", dbAvailableSeat.TicketClassId);
            return View(dbAvailableSeat);
        }

        // GET: DbAvailableSeats/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbAvailableSeat = await _context.DbAvailableSeat
                .Include(d => d.DbFlight)
                .Include(d => d.DbTicketClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbAvailableSeat == null)
            {
                return NotFound();
            }

            return View(dbAvailableSeat);
        }

        // POST: DbAvailableSeats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbAvailableSeat = await _context.DbAvailableSeat.FindAsync(id);
            _context.DbAvailableSeat.Remove(dbAvailableSeat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbAvailableSeatExists(long id)
        {
            return _context.DbAvailableSeat.Any(e => e.Id == id);
        }
    }
}
