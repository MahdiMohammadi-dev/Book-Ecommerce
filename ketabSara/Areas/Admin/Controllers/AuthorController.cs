using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
