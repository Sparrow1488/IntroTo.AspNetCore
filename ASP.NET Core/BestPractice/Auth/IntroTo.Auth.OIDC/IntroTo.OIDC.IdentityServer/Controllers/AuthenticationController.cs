using System.Security.Claims;
using AspNet.Security.OpenId.Steam;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IntroTo.OpenIdConnect.Controllers;

[ApiController, Route("[controller]")]
public class AuthenticationController : Controller
{
    [HttpGet("login")]
    public IActionResult Login(string? returnUrl = "/")
    {
        return Challenge(
            new AuthenticationProperties() {
                IsPersistent = true,
                RedirectUri = returnUrl ?? "/"
            },
            SteamAuthenticationDefaults.AuthenticationScheme);
    }
    
    [HttpGet("custom-login")]
    public IActionResult CustomLogin(string? returnUrl = "/")
    {
        var claims = new[]
        {
            new Claim(
                JwtClaimTypes.Subject,
                "custom-subject",
                ClaimValueTypes.String,
                "https://localhost:3001",
                "https://localhost:3001"
            )
        };
        
        var identities = new ClaimsIdentity(claims, "CustomAuthScheme");
        var principal = new ClaimsPrincipal(identities);
        var properties = new AuthenticationProperties()
        {
            IsPersistent = true
        };

        return SignIn(principal, properties);
    }
}