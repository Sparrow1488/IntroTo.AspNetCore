using AspNet.Security.OpenId.Steam;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IntroTo.OpenIdConnect.Controllers;

[ApiController, Route("[controller]")]
public class AuthenticationController : Controller
{
    [HttpGet("login")]
    public IActionResult Login(string? returnUrl = "/swagger/index.html")
    {
        return Challenge(
            new AuthenticationProperties()
            {
                IsPersistent = true,
                RedirectUri = returnUrl
            },
            SteamAuthenticationDefaults.AuthenticationScheme);
    }
}