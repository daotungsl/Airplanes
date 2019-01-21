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
    public class DbTicketClassesController : Controller
    {
        private readonly AirplanesContext _context;

        public DbTicketClassesController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbTicketClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.DbTicketClass.ToListAsync());
        }

        // GET: DbTicketClasses/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTicketClass = await _context.DbTicketClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbTicketClass == null)
            {
                return NotFound();
            }

            return View(dbTicketClass);
        }

        // GET: DbTicketClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbTicketClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketClassName,Price,CreatedAt,UpdatedAt")] DbTicketClass dbTicketClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbTicketClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbTicketClass);
        }

        // GET: DbTicketClasses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTicketClass = await _context.DbTicketClass.FindAsync(id);
            if (dbTicketClass == null)
            {
                return NotFound();
            }
            return View(dbTicketClass);
        }

        // POST: DbTicketClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TicketClassName,Price,CreatedAt,UpdatedAt")] DbTicketClass dbTicketClass)
        {
            if (id != dbTicketClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbTicketClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbTicketClassExists(dbTicketClass.Id))
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
            return View(dbTicketClass);
        }

        // GET: DbTicketClasses/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbTicketClass = await _context.DbTicketClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbTicketClass == null)
            {
                return NotFound();
            }

            return View(dbTicketClass);
        }

        // POST: DbTicketClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbTicketClass = await _context.DbTicketClass.FindAsync(id);
            _context.DbTicketClass.Remove(dbTicketClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbTicketClassExists(long id)
        {
            return _context.DbTicketClass.Any(e => e.Id == id);
        }
    }
}
