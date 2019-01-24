using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airplanes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Airplanes.Controllers.AdminController
{
    public class AdminViewController : Controller
    {
        private readonly RoleStore<IdentityRole> _roleStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AirplanesContext _context;

        public AdminViewController(RoleManager<IdentityRole> roleManager, RoleStore<IdentityRole> roleStore, AirplanesContext context)
        {
            _context = context;
            _roleStore = roleStore;
            _roleManager = roleManager;
        }

        public static List<IdentityRole> roles;
        [BindProperty]
        public Roles Role { get; set; }
        public class Roles : IdentityRole
        {
        }

        public async Task<IActionResult> Index()
        {
            return View("Roles/Index", roles);
        }
        public IActionResult Create()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Edit()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Details()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}