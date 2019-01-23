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
    public class DbAirportsController : Controller
    {
        private readonly AirplanesContext _context;

        public DbAirportsController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbAirports
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbAirport.Include(d => d.DbCity)/*.Include(d => d.DbCountry)*/;
            return View(await AirplanesContext.ToListAsync());
        }

        // GET: DbAirports/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbAirport = await _context.DbAirport
                .Include(d => d.DbCity)
                //.Include(d => d.DbCountry)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbAirport == null)
            {
                return NotFound();
            }

            return View(dbAirport);
        }

        // GET: DbAirports/Create
        public IActionResult Create()
        {
            ViewData["DbCityId"] = new SelectList(_context.DbCity, "Id", "Id");
            //ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id");
            return View();
        }

        // POST: DbAirports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AirportName,DbCityId,DbCountryId,CreatedAt,UpdatedAt")] DbAirport dbAirport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbAirport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DbCityId"] = new SelectList(_context.DbCity, "Id", "Id", dbAirport.DbCityId);
            //ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id", dbAirport.CountryId);
            return View(dbAirport);
        }

        // GET: DbAirports/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbAirport = await _context.DbAirport.FindAsync(id);
            if (dbAirport == null)
            {
                return NotFound();
            }
            ViewData["DbCityId"] = new SelectList(_context.DbCity, "Id", "Id", dbAirport.DbCityId);
            //ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id", dbAirport.CountryId);
            return View(dbAirport);
        }

        // POST: DbAirports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,AirportName,DbCityId,DbCountryId,CreatedAt,UpdatedAt")] DbAirport dbAirport)
        {
            if (id != dbAirport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbAirport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbAirportExists(dbAirport.Id))
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
            ViewData["DbCityId"] = new SelectList(_context.DbCity, "Id", "Id", dbAirport.DbCityId);
            //ViewData["DbCountryId"] = new SelectList(_context.DbCountry, "Id", "Id", dbAirport.CountryId);
            return View(dbAirport);
        }

        // GET: DbAirports/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbAirport = await _context.DbAirport
                .Include(d => d.DbCity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbAirport == null)
            {
                return NotFound();
            }

            return View(dbAirport);
        }

        // POST: DbAirports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbAirport = await _context.DbAirport.FindAsync(id);
            _context.DbAirport.Remove(dbAirport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbAirportExists(long id)
        {
            return _context.DbAirport.Any(e => e.Id == id);
        }
    }
}
