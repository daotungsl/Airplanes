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
using Microsoft.AspNetCore.Identity;

namespace Airplanes.Controllers
{
    public class DbOrdersController : Controller
    {
        private readonly AirplanesContext _context;
        private readonly UserManager<AirplanesUser> _userManager;
        private readonly SignInManager<AirplanesUser> _signInManager;
        public DbOrdersController(AirplanesContext context, UserManager<AirplanesUser> userManager,
            SignInManager<AirplanesUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // GET: DbOrders
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Index()
        {
            var AirplanesContext = _context.DbOrder.Include(d => d.AirplanesUser);
            return View(await AirplanesContext.ToListAsync());
        }

        // GET: DbOrders/Details/5
        [Authorize(Roles = "Admin, User, Manager")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbOrder = await _context.DbOrder
                .Include(d => d.AirplanesUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbOrder == null)
            {
                return NotFound();
            }

            return View(dbOrder);
        }

        public static long fId;
        // GET: DbOrders/Create
        [Authorize(Roles = "User, Admin, Manager")]
        public IActionResult Create(long flightId)
        {
            fId = flightId;
            //ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id");
            return View();
        }

        // POST: DbOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UId,Adult,Child,Quantity,CreatedAt,Status")] DbOrder dbOrder)
        {
            if (ModelState.IsValid)
            {
                if (_signInManager.IsSignedIn(User))
                {
                    dbOrder.UId = _userManager.GetUserId(User);
                    dbOrder.Quantity = dbOrder.Child + dbOrder.Adult;
                    _context.Add(dbOrder);
                    await _context.SaveChangesAsync();
                    return /*RedirectToAction("PickUpTicket", "UsersView");*/
                        Redirect("/UsersView/PickUpTicket?flightId=" + fId + "&orderId=" + dbOrder.Id);
                }
                
            }
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbOrder.UId);
            return View(dbOrder);
        }

        // GET: DbOrders/Edit/5
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbOrder = await _context.DbOrder.FindAsync(id);
            if (dbOrder == null)
            {
                return NotFound();
            }
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbOrder.UId);
            return View(dbOrder);
        }

        // POST: DbOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UId,Adult,Child,Quantity,CreatedAt,Status")] DbOrder dbOrder)
        {
            if (id != dbOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbOrderExists(dbOrder.Id))
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
            ViewData["UId"] = new SelectList(_context.Set<AirplanesUser>(), "Id", "Id", dbOrder.UId);
            return View(dbOrder);
        }

        // GET: DbOrders/Delete/5
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbOrder = await _context.DbOrder
                .Include(d => d.AirplanesUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbOrder == null)
            {
                return NotFound();
            }

            return View(dbOrder);
        }

        // POST: DbOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dbOrder = await _context.DbOrder.FindAsync(id);
            _context.DbOrder.Remove(dbOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbOrderExists(long id)
        {
            return _context.DbOrder.Any(e => e.Id == id);
        }
    }
}
