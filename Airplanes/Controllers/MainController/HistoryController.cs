using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airplanes.Models;
using Airplanes.Models.Custom;
using Airplanes.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airplanes.Controllers.MainController
{
    public class HistoryController : Controller
    {
        private readonly AirplanesContext _context;
        private readonly UserManager<AirplanesUser> _userManager;
        private readonly SignInManager<AirplanesUser> _signInManager;
        private List<DbFlight> flights = new List<DbFlight>();
        MailVerify mv = new MailVerify();
        public HistoryController(AirplanesContext context, UserManager<AirplanesUser> userManager,
            SignInManager<AirplanesUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public History history { get; set; }

        public class History
        {
            public string UId { get; set; }
            public List<DbOrder> DbOrders { get; set; }
            public DbTicket DbTicket { get; set; }
            public DbTicketClass DbTicketClass { get; set; }
        }
        private List<DbOrder> Orders;
        public async Task<IActionResult> HistoryOrder(string UId)
        {
            ViewData["UId1"] = UId;
            if (UId != null)
            {
                Orders = await _context.DbOrder.Where(o => o.UId == UId).ToListAsync();
                return View(Orders);
            }

            return View();
        }

        public async Task<IActionResult> DetailOrder(long? id, string uId)
        {
            ViewData["OrderId"] = id;
            ViewData["UId"] = uId;
            ViewData["AId"] = uId;
            if (id == null)
            {
                return NotFound();
            }

            var dbTicket = await _context.DbTicket
                .Include(d => d.DbFlight)
                .Include(d => d.DbOrder)
                .Include(d => d.DbPassenger)
                .Include(d => d.DbTicketClass)
                .Where(m => m.DbOrderId == id).ToListAsync();
            if (dbTicket == null)
            {
                return NotFound();
            }

            return View(dbTicket);
        }

        public async Task<IActionResult> Cancel(long? id, long? oId, string uId)
        {
            if (id == null)
            {
                return NotFound();
            }

            DbTicket ticket = _context.DbTicket.FirstOrDefault(t => t.Id == id);
            ticket.Status = TicketStatus.Cancel;

            _context.DbTicket.Update(ticket);
            await _context.SaveChangesAsync();

            DbTicketClass ticketClass = _context.DbTicketClass.FirstOrDefault(c => c.Id == ticket.DbTicketClassId);
            DbOrder order = _context.DbOrder.FirstOrDefault(o => o.Id == oId);
            AirplanesUser user = _userManager.Users.FirstOrDefault(u => u.Id == uId);
            user.RewardPoints = user.RewardPoints - (ticketClass.Points * order.Quantity);
            await _userManager.UpdateAsync(user);

            return Redirect("/History/DetailOrder?id=" + oId);
        }
    }
}