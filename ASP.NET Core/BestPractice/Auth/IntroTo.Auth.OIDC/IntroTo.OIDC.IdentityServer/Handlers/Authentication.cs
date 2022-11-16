using System.Security.Claims;
using AspNet.Security.OpenId;
using AspNet.Security.OpenId.Steam;
using IdentityModel;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication;

namespace IntroTo.OpenIdConnect.Handlers;

public static class Authentication
{
    public static Task OnAuthentication(OpenIdAuthenticatedContext context)
    {
        var steamIdClaim = context.Identity?.FindFirst(ClaimTypes.NameIdentifier)
                             ?? throw new InvalidOperationException("NameIdentifier not found");
        var steamId = steamIdClaim.Value[37..];

        var steamNicknameClaim = context.Identity?.FindFirst(ClaimTypes.Name)
                                    ?? throw new InvalidOperationException("Name not found");;
        var steamName = steamNicknameClaim.Value;
        
        List<Claim> userClaims = new () {
            new Claim(
                JwtClaimTypes.Subject,
                steamId,
                ClaimValueTypes.String,
                "https://localhost:3001",
                SteamAuthenticationDefaults.Authority
            ),
            new Claim(
                    JwtClaimTypes.Email,
                    "ilyaokubev@gmail.com",
                    ClaimValueTypes.String,
                    "https://localhost:3001",
                    "https://localhost:3001"
            ),
            new Claim(
                "client_country",
                "Russia",
                ClaimValueTypes.String,
                "https://localhost:3001",
                "https://localhost:3001"
            ),
            new Claim(
                "client_name",
                steamName,
                ClaimValueTypes.String,
                "https://localhost:3001",
                "https://localhost:3001"
            ),
            new Claim(
                ClaimTypes.Role,
                "User",
                ClaimValueTypes.String,
                "https://localhost:3001",
                "https://localhost:3001"
            ),
        };

        var identity = new ClaimsIdentity(
            userClaims,
            SteamAuthenticationDefaults.AuthenticationScheme
        );

        var principal = new ClaimsPrincipal( identity );

        var ticket = new AuthenticationTicket(
            principal,
            context.Properties,
            SteamAuthenticationDefaults.AuthenticationScheme
        );

        context.Ticket = ticket;
        return Task.CompletedTask;
    }
}