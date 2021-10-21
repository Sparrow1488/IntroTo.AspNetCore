using AuthorizationNETCore.DatabasePractice.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationNETCore.DatabasePractice.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            IActionResult requestResult = View(vm);
            if (ModelState.IsValid)
            {
                requestResult = Redirect(vm.ReturnUrl);
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Role, "User")
                };
                var identity = new ClaimsIdentity(claims, "Cookie");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("Cookie", principal);
            }
            return requestResult;
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }

        public IActionResult Profile()
        {
            return View();
        }
        
    }
}
