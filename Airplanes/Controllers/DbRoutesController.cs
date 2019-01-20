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
    public class DbRoutesController : Controller
    {
        private readonly AirplanesContext _context;

        public DbRoutesController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbRoutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DbRoute.ToListAsync());
        }

        // GET: DbRoutes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbRoute = await _context.DbRoute
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbRoute == null)
            {
                return NotFound();
            }

            return View(dbRoute);
        }

        // GET: DbRoutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FromAirport,ToAirport,CreatedAt,UpdatedAt")] DbRoute dbRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbRoute);
        }

        // GET: DbRoutes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbRoute = await _context.DbRoute.FindAsync(id);
            if (dbRoute == null)
            {
                return NotFound();
            }
            return View(dbRoute);
        }

        // POST: DbRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FromAirport,ToAirport,CreatedAt,UpdatedAt")] DbRoute dbRoute)
        {
            if (id != dbRoute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbRouteExists(dbRoute.Id))
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
            return View(dbRoute);
        }

        // GET: DbRoutes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbRoute = await _context.DbRoute
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbRoute == null)
            {
                return NotFound();
            }

            return View(dbRoute);
        }

        // POST: DbRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbRoute = await _context.DbRoute.FindAsync(id);
            _context.DbRoute.Remove(dbRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbRouteExists(long id)
        {
            return _context.DbRoute.Any(e => e.Id == id);
        }
    }
}
