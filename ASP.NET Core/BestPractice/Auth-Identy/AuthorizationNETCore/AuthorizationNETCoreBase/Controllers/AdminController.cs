﻿using AuthorizationNETCoreBase.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizationNETCoreBase.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
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
            string scheme = "Cookie";
            IActionResult requestResult = View(vm);
            if (ModelState.IsValid)
            {
                var identies = new List<Claim>()
                {
                    new Claim("Demo", "Value")
                };
                var identy = new ClaimsIdentity(identies, scheme);
                var principal = new ClaimsPrincipal(identy);
                await HttpContext.SignInAsync(scheme, principal);
                requestResult = Redirect(vm.ReturnUrl);
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
