using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult RegisterIndex()
        {
            return View("Register");
        }
        public IActionResult LoginIndex()
        {
            return View("Login");
        }
    }
}
