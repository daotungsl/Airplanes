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
    
    public class DbNewsController : Controller
    {
        private readonly AirplanesContext _context;

        public DbNewsController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbNews
        public async Task<IActionResult> Index()
        {
            return View(await _context.DbNews.ToListAsync());
        }

        // GET: DbNews/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbNews = await _context.DbNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbNews == null)
            {
                return NotFound();
            }

            return View(dbNews);
        }

        // GET: DbNews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,Author,Date,CreatedAt,UpdatedAt")] DbNews dbNews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbNews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbNews);
        }

        // GET: DbNews/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbNews = await _context.DbNews.FindAsync(id);
            if (dbNews == null)
            {
                return NotFound();
            }
            return View(dbNews);
        }

        // POST: DbNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Content,Author,Date,CreatedAt,UpdatedAt")] DbNews dbNews)
        {
            if (id != dbNews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbNews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbNewsExists(dbNews.Id))
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
            return View(dbNews);
        }

        // GET: DbNews/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbNews = await _context.DbNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbNews == null)
            {
                return NotFound();
            }

            return View(dbNews);
        }

        // POST: DbNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbNews = await _context.DbNews.FindAsync(id);
            _context.DbNews.Remove(dbNews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> NewsView()
        {
            return View(await _context.DbNews.ToListAsync());
        }

        private bool DbNewsExists(long id)
        {
            return _context.DbNews.Any(e => e.Id == id);
        }


    }
}