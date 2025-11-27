using KetabSara.DataLayer.Models;
using ketabSara.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ketabSara.Controllers
{
    public class AuthController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult RegisterIndex()
        {
            return View("Register");
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", registerUserViewModel);
            }
            
            var user = new User()
                { Email = registerUserViewModel.EmailAddress, UserName = registerUserViewModel.EmailAddress,};

            var result = await _userManager.CreateAsync(user,registerUserViewModel.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index","Home");
            }

            return View(registerUserViewModel);
        }



        public IActionResult LoginIndex()
        {
            return View("Login");
        }

        [HttpPost]

        
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password,
                loginViewModel.RememeberMe, false);

            if (result.Succeeded)
            {
             return   RedirectToAction("Index","Home");
            }
           
            return View(loginViewModel);
          
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LoginIndex");
        }
    }
}
