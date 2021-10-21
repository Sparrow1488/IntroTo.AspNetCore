using AuthorizationNETCore.Database.Database;
using AuthorizationNETCoreBase.Database.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationNETCoreBase.Database.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "Administrator")]
        public IActionResult Administrator()
        {
            return View();
        }

        [Authorize(Policy = "Manager")]
        public IActionResult Manager()
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
            string scheme = "Cookie";
            IActionResult requestResult = View(vm);
            if (ModelState.IsValid)
            {
                var user = _db.Users.SingleOrDefault(user => user.Name == vm.UserName && 
                                                                                            user.Password == vm.Password);
                if(user != null)
                {
                    var identies = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, vm.UserName),
                        new Claim(ClaimTypes.Role, "Administrator")
                    };
                    var identy = new ClaimsIdentity(identies, scheme);
                    var principal = new ClaimsPrincipal(identy);
                    await HttpContext.SignInAsync(scheme, principal);
                    requestResult = Redirect(vm.ReturnUrl);
                }
                else 
                    ModelState.AddModelError("Login", "User not found!");
            }
            return requestResult;
        }

        public async Task<IActionResult> SignOut()
        {
            string scheme = "Cookie";
            await HttpContext.SignOutAsync(scheme);
            return Redirect("/Home/Index");
        }
    }
}
