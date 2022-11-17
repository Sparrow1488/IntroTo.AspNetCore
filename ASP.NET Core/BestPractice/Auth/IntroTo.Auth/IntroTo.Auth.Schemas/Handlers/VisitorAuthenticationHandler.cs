using System.Security.Claims;
using System.Text.Encodings.Web;
using IntroTo.Auth.Schemas.Schemas;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace IntroTo.Auth.Schemas.Handlers;

public class LocalAuthenticationHandler : CookieAuthenticationHandler
{
    public LocalAuthenticationHandler(
        IOptionsMonitor<CookieAuthenticationOptions> options, 
        ILoggerFactory logger, 
        UrlEncoder encoder, 
        ISystemClock clock)
    : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var result = await base.HandleAuthenticateAsync();
        if (result.Succeeded)   
            return result;

        var tempId = Guid.NewGuid().ToString();
        var claims = new[] { new Claim(ClaimTypes.NameIdentifier, tempId) };
        var identity = new ClaimsIdentity(claims, ApiSchemes.VisitorAuthenticationScheme);
        var user = new ClaimsPrincipal(identity);
        
        await Context.SignInAsync(user, result.Properties);
        return AuthenticateResult.Success(new AuthenticationTicket(user, ApiSchemes.VisitorAuthenticationScheme));
    }
}