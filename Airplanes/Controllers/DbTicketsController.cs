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
    public class DbTicketsController : Controller
    {
        private readonly AirplanesContext _context;

        public DbTicketsController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbTickets
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbTicket.Include(d => d.DbFlight).Include(d => d.DbOrder).Include(d => d.DbPassenger).Include(d => d.DbTicketClass);
            return View(await AirplanesContext.ToListAsync());
        }

        // GET: DbTickets/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTicket = await _context.DbTicket
                .Include(d => d.DbFlight)
                .Include(d => d.DbOrder)
                .Include(d => d.DbPassenger)
                .Include(d => d.DbTicketClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbTicket == null)
            {
                return NotFound();
            }

            return View(dbTicket);
        }

        // GET: DbTickets/Create
        public IActionResult Create()
        {
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id");
            ViewData["DbOrderId"] = new SelectList(_context.DbOrder, "Id", "Id");
            ViewData["DbPassengerId"] = new SelectList(_context.DbPassenger, "Id", "Id");
            ViewData["DbTicketClassId"] = new SelectList(_context.DbTicketClass, "Id", "Id");
            return View();
        }

        // POST: DbTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DbOrderId,DbTicketClassId,DbFlightId,DbPassengerId,Price,CreatedAt,UpdatedAt,Status")] DbTicket dbTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbTicket.DbFlightId);
            ViewData["DbOrderId"] = new SelectList(_context.DbOrder, "Id", "Id", dbTicket.DbOrderId);
            ViewData["DbPassengerId"] = new SelectList(_context.DbPassenger, "Id", "Id", dbTicket.DbPassengerId);
            ViewData["DbTicketClassId"] = new SelectList(_context.DbTicketClass, "Id", "Id", dbTicket.DbTicketClassId);
            return View(dbTicket);
        }

        // GET: DbTickets/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTicket = await _context.DbTicket.FindAsync(id);
            if (dbTicket == null)
            {
                return NotFound();
            }
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbTicket.DbFlightId);
            ViewData["DbOrderId"] = new SelectList(_context.DbOrder, "Id", "Id", dbTicket.DbOrderId);
            ViewData["DbPassengerId"] = new SelectList(_context.DbPassenger, "Id", "Id", dbTicket.DbPassengerId);
            ViewData["DbTicketClassId"] = new SelectList(_context.DbTicketClass, "Id", "Id", dbTicket.DbTicketClassId);
            return View(dbTicket);
        }

        // POST: DbTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DbOrderId,DbTicketClassId,DbFlightId,DbPassengerId,Price,CreatedAt,UpdatedAt,Status")] DbTicket dbTicket)
        {
            if (id != dbTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbTicketExists(dbTicket.Id))
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
            ViewData["DbFlightId"] = new SelectList(_context.DbFlight, "Id", "Id", dbTicket.DbFlightId);
            ViewData["DbOrderId"] = new SelectList(_context.DbOrder, "Id", "Id", dbTicket.DbOrderId);
            ViewData["DbPassengerId"] = new SelectList(_context.DbPassenger, "Id", "Id", dbTicket.DbPassengerId);
            ViewData["DbTicketClassId"] = new SelectList(_context.DbTicketClass, "Id", "Id", dbTicket.DbTicketClassId);
            return View(dbTicket);
        }

        // GET: DbTickets/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTicket = await _context.DbTicket
                .Include(d => d.DbFlight)
                .Include(d => d.DbOrder)
                .Include(d => d.DbPassenger)
                .Include(d => d.DbTicketClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbTicket == null)
            {
                return NotFound();
            }

            return View(dbTicket);
        }

        // POST: DbTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbTicket = await _context.DbTicket.FindAsync(id);
            _context.DbTicket.Remove(dbTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbTicketExists(long id)
        {
            return _context.DbTicket.Any(e => e.Id == id);
        }
    }
}
