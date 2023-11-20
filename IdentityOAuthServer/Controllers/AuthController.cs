using IdentityOAuthServer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityOAuthServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> siginManager;

        public AuthController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _siginManager)
        {
            userManager = _userManager;
            siginManager = _siginManager;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var res = await siginManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if(res.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            return View();
        }
    }
}
