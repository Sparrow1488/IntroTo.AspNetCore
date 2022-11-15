using System.Threading.Channels;
using AspNet.Security.OpenId.Steam;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IntroTo.OpenIdConnect.Controllers;

[ApiController, Route("[controller]")]
public class AuthorizationController : Controller
{
    [HttpGet("login")]
    public IActionResult Login(string redirectUri = "/swagger/index.html")
    {
        return Challenge(
            new AuthenticationProperties()
            {
                IsPersistent = true,
                RedirectUri = redirectUri
            },
            SteamAuthenticationDefaults.AuthenticationScheme);
    }
}