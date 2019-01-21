using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airplanes.Models;
using Airplanes.Models.Custom;

namespace Airplanes.Controllers
{
    public class DbRewardPointsLogsController : Controller
    {
        private readonly AirplanesContext _context;

        public DbRewardPointsLogsController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbRewardPointsLogs
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbRewardPointsLog.Include(d => d.AirplanesUser);
            return View(await AirplanesContext.ToListAsync());
        }

        // GET: DbRewardPointsLogs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbRewardPointsLog = await _context.DbRewardPointsLog
                .Include(d => d.AirplanesUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbRewardPointsLog == null)
            {
                return NotFound();
            }

            return View(dbRewardPointsLog);
        }

        // GET: DbRewardPointsLogs/Create
        public IActionResult Create()
        {
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id");
            return View();
        }

        // POST: DbRewardPointsLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UId,NameLog,Points,Note,CreatedAt")] DbRewardPointsLog dbRewardPointsLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbRewardPointsLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbRewardPointsLog.UId);
            return View(dbRewardPointsLog);
        }

        // GET: DbRewardPointsLogs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbRewardPointsLog = await _context.DbRewardPointsLog.FindAsync(id);
            if (dbRewardPointsLog == null)
            {
                return NotFound();
            }
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbRewardPointsLog.UId);
            return View(dbRewardPointsLog);
        }

        // POST: DbRewardPointsLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UId,NameLog,Points,Note,CreatedAt")] DbRewardPointsLog dbRewardPointsLog)
        {
            if (id != dbRewardPointsLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbRewardPointsLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbRewardPointsLogExists(dbRewardPointsLog.Id))
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
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbRewardPointsLog.UId);
            return View(dbRewardPointsLog);
        }

        // GET: DbRewardPointsLogs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbRewardPointsLog = await _context.DbRewardPointsLog
                .Include(d => d.AirplanesUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbRewardPointsLog == null)
            {
                return NotFound();
            }

            return View(dbRewardPointsLog);
        }

        // POST: DbRewardPointsLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbRewardPointsLog = await _context.DbRewardPointsLog.FindAsync(id);
            _context.DbRewardPointsLog.Remove(dbRewardPointsLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbRewardPointsLogExists(long id)
        {
            return _context.DbRewardPointsLog.Any(e => e.Id == id);
        }
    }
}
