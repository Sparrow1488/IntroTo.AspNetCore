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
        
        // For Example: get user claims from db
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, "ApiUser"),
            new Claim(ClaimTypes.Email, "user@gmail.com")
        };
        var identity = new ClaimsIdentity(claims, ApiSchemas.LocalAuthenticationSchema);
        var user = new ClaimsPrincipal(identity);
        
        await Context.SignInAsync(ApiSchemas.LocalAuthenticationSchema, user, new AuthenticationProperties
        {
            RedirectUri = "/me"
        });
        return AuthenticateResult.Success(new AuthenticationTicket(user, ApiSchemas.LocalAuthenticationSchema));
    }
}