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
    public class DbCountriesController : Controller
    {
        private readonly AirplanesContext _context;

        public DbCountriesController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbCountries
        public async Task<IActionResult> Index()
        {
            return View(await _context.DbCountry.ToListAsync());
        }

        // GET: DbCountries/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCountry = await _context.DbCountry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbCountry == null)
            {
                return NotFound();
            }

            return View(dbCountry);
        }

        // GET: DbCountries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbCountries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountryName,CreatedAt,UpdatedAt")] DbCountry dbCountry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbCountry);
        }

        // GET: DbCountries/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCountry = await _context.DbCountry.FindAsync(id);
            if (dbCountry == null)
            {
                return NotFound();
            }
            return View(dbCountry);
        }

        // POST: DbCountries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CountryName,CreatedAt,UpdatedAt")] DbCountry dbCountry)
        {
            if (id != dbCountry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbCountryExists(dbCountry.Id))
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
            return View(dbCountry);
        }

        // GET: DbCountries/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCountry = await _context.DbCountry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbCountry == null)
            {
                return NotFound();
            }

            return View(dbCountry);
        }

        // POST: DbCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbCountry = await _context.DbCountry.FindAsync(id);
            _context.DbCountry.Remove(dbCountry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbCountryExists(long id)
        {
            return _context.DbCountry.Any(e => e.Id == id);
        }
    }
}
