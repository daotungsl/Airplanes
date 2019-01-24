using Airplanes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Airplanes.Controllers.MainController;

namespace Airplanes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms_of_service()
        {
            return View();
        }

        public IActionResult Dieu_le_van_chuyen()
        {
            return View();
        }

        public IActionResult EagleAirline()
        {
            return View();
        }

        public IActionResult Yeu_cau_ve_giay_to()
        {
            return View();
        }

        public IActionResult Thong_tin_tim_kiem_hanh_ly()
        {
            return View();
        }

        public IActionResult Thong_tin_noi_chuyen()
        {
            return View();
        }

        public IActionResult Dich_vu_tren_chuyen_bay()
        {
            return View();
        }

        public IActionResult Dich_vu_hanh_ly()
        {
            return View();
        }

        public IActionResult Dich_vu_thu_tuc_nhanh()
        {
            return View();
        }

        public IActionResult Dich_vu_dac_biet()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}