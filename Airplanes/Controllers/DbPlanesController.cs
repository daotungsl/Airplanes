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
    public class DbPlanesController : Controller
    {
        private readonly AirplanesContext _context;

        public DbPlanesController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbPlanes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DbPlane.ToListAsync());
        }

        // GET: DbPlanes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbPlane = await _context.DbPlane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbPlane == null)
            {
                return NotFound();
            }

            return View(dbPlane);
        }

        // GET: DbPlanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbPlanes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlaneName,MadeIn,Image,UrlTemplate,CreatedAt,UpdatedAt")] DbPlane dbPlane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbPlane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbPlane);
        }

        // GET: DbPlanes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbPlane = await _context.DbPlane.FindAsync(id);
            if (dbPlane == null)
            {
                return NotFound();
            }
            return View(dbPlane);
        }

        // POST: DbPlanes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PlaneName,MadeIn,Image,UrlTemplate,CreatedAt,UpdatedAt")] DbPlane dbPlane)
        {
            if (id != dbPlane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbPlane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbPlaneExists(dbPlane.Id))
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
            return View(dbPlane);
        }

        // GET: DbPlanes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbPlane = await _context.DbPlane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbPlane == null)
            {
                return NotFound();
            }

            return View(dbPlane);
        }

        // POST: DbPlanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbPlane = await _context.DbPlane.FindAsync(id);
            _context.DbPlane.Remove(dbPlane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbPlaneExists(long id)
        {
            return _context.DbPlane.Any(e => e.Id == id);
        }
    }
}
