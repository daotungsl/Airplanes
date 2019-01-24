using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airplanes.Models;
using Airplanes.Models.Custom;
using Microsoft.AspNetCore.Authorization;

namespace Airplanes.Controllers
{
    public class DbPassengersController : Controller
    {
        private readonly AirplanesContext _context;

        public DbPassengersController(AirplanesContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin, Manager")]
        // GET: DbPassengers
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbPassenger.Include(d => d.AirplanesUser);
            return View(await AirplanesContext.ToListAsync());
        }

        [Authorize(Roles = "Admin, Manager, User")]
        // GET: DbPassengers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbPassenger = await _context.DbPassenger
                .Include(d => d.AirplanesUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbPassenger == null)
            {
                return NotFound();
            }

            return View(dbPassenger);
        }

        [Authorize(Roles = "Admin, Manager, User")]
        // GET: DbPassengers/Create
        public IActionResult Create()
        {
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id");
            return View();
        }

        // POST: DbPassengers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UId,FullName,Gender,Phone,Birthday,CreatedAt,UpdatedAt")] DbPassenger dbPassenger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbPassenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbPassenger.UId);
            return View(dbPassenger);
        }

        [Authorize(Roles = "Admin, Manager, User")]
        // GET: DbPassengers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbPassenger = await _context.DbPassenger.FindAsync(id);
            if (dbPassenger == null)
            {
                return NotFound();
            }
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbPassenger.UId);
            return View(dbPassenger);
        }

        // POST: DbPassengers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UId,FullName,Gender,Phone,Birthday,CreatedAt,UpdatedAt")] DbPassenger dbPassenger)
        {
            if (id != dbPassenger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbPassenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbPassengerExists(dbPassenger.Id))
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
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbPassenger.UId);
            return View(dbPassenger);
        }

        [Authorize(Roles = "Admin, Manager")]
        // GET: DbPassengers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbPassenger = await _context.DbPassenger
                .Include(d => d.AirplanesUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbPassenger == null)
            {
                return NotFound();
            }

            return View(dbPassenger);
        }

        // POST: DbPassengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbPassenger = await _context.DbPassenger.FindAsync(id);
            _context.DbPassenger.Remove(dbPassenger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbPassengerExists(long id)
        {
            return _context.DbPassenger.Any(e => e.Id == id);
        }
    }
}
