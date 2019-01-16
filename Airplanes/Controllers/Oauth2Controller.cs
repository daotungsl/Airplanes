using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Airplanes.Models;
using Airplanes.Models.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Airplanes.Controllers
{
    public class Oauth2Controller : Controller
    {
        private readonly AirplanesContext _context;
        private readonly IMemoryCache _memoryCache;


        public Oauth2Controller(AirplanesContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Authentication()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Authentication(LoginInformation loginInformation)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            DbUser existUser = _context.DbUser.FirstOrDefault(u => u.Username == loginInformation.Username);
            if (existUser == null)
            {
                return View("Login");
            }

            if (Security.Security.GetInstance().EncryptPassword(loginInformation.Password, existUser.Salt) !=
                existUser.Password)
            {
                return View("Login");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}