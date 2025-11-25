using System.Diagnostics;
using ketabSara.Models;
using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult AllProducts()
        {

            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
