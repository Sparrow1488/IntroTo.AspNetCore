using IntroTo.OIDC.Shared.Schemes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IntroTo.OIDC.Client.Controllers;

[ApiController, Route("[controller]")]
public class AuthenticationController : Controller
{
    [HttpGet("login")]
    public IActionResult Login(string? returnUrl = "/")
    {
        var properties = new AuthenticationProperties()
        {
            RedirectUri = returnUrl ?? "/",
            IsPersistent = true
        };
        return Challenge(
            properties, 
            CustomIdentityAuthenticationScheme.AuthenticationScheme);
    }
}