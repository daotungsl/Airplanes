using System;
using System.Collections;
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
    public class DbCitiesController : Controller
    {
        private readonly AirplanesContext _context;

        public DbCitiesController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbCities
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbCity.Include(d => d.DbCountry);
            return View(await AirplanesContext.ToListAsync());
        }

        // GET: DbCities/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCity = await _context.DbCity
                .Include(d => d.DbCountry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbCity == null)
            {
                return NotFound();
            }

            return View(dbCity);
        }

        // GET: DbCities/Create
        public IActionResult Create()
        {
            ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id");
            return View();
        }
        

        // POST: DbCities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,ZipCode,DbCountryId,AirportStatus, CreatedAt, UpdatedAt")] DbCity dbCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id", dbCity.DbCountryId);
            return View(dbCity);
        }

        // GET: DbCities/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCity = await _context.DbCity.FindAsync(id);
            if (dbCity == null)
            {
                return NotFound();
            }
            ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id", dbCity.DbCountryId);
            return View(dbCity);
        }

        // POST: DbCities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Code,Name,ZipCode,DbCountryId,AirportStatus, CreatedAt, UpdatedAt")] DbCity dbCity)
        {
            if (id != dbCity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbCityExists(dbCity.Id))
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
            ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id", dbCity.DbCountryId);
            return View(dbCity);
        }

        // GET: DbCities/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCity = await _context.DbCity
                .Include(d => d.DbCountry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbCity == null)
            {
                return NotFound();
            }

            return View(dbCity);
        }

        // POST: DbCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbCity = await _context.DbCity.FindAsync(id);
            _context.DbCity.Remove(dbCity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbCityExists(long id)
        {
            return _context.DbCity.Any(e => e.Id == id);
        }
    }
}
