using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Airplanes.Models;
using Airplanes.Models;

namespace Airplanes.Controllers
{
    public class DbUsersController : Controller
    {
        private readonly AirplanesContext _context;

        public DbUsersController(AirplanesContext context)
        {
            _context = context;
        }

        // GET: DbUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.DbUser.ToListAsync());
        }

        // GET: DbUsers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbUser = await _context.DbUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbUser == null)
            {
                return NotFound();
            }

            return View(dbUser);
        }

        // GET: DbUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UId,Username,Password,ConfirmPassword,Salt,FullName,Gender,Birthday,IdNumber,Phone,Email,Address,RewardPoints,EmailVerifyStatus,PhoneVerifyStatus,CreatedAt,UpdatedAt,Status")] DbUser dbUser)
        {
            if (ModelState.IsValid)
            {
                dbUser.Salt = Security.Security.GetInstance().Salt();
                dbUser.Password = Security.Security.GetInstance().EncryptPassword(dbUser.Password, dbUser.Salt);
                dbUser.ConfirmPassword =
                    Security.Security.GetInstance().EncryptPassword(dbUser.ConfirmPassword, dbUser.Salt);
                _context.Add(dbUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbUser);
        }

        // GET: DbUsers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbUser = await _context.DbUser.FindAsync(id);
            if (dbUser == null)
            {
                return NotFound();
            }
            return View(dbUser);
        }

        // POST: DbUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UId,Username,Password,ConfirmPassword,Salt,FullName,Gender,Birthday,IdNumber,Phone,Email,Address,RewardPoints,EmailVerifyStatus,PhoneVerifyStatus,CreatedAt,UpdatedAt,Status")] DbUser dbUser)
        {
            if (id != dbUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbUserExists(dbUser.Id))
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
            return View(dbUser);
        }

        // GET: DbUsers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbUser = await _context.DbUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbUser == null)
            {
                return NotFound();
            }

            return View(dbUser);
        }

        // POST: DbUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbUser = await _context.DbUser.FindAsync(id);
            _context.DbUser.Remove(dbUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbUserExists(long id)
        {
            return _context.DbUser.Any(e => e.Id == id);
        }
    }
}
