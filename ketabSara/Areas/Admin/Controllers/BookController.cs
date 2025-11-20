using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
