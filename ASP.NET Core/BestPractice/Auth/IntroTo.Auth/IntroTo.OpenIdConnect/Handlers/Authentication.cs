using System.Security.Claims;
using AspNet.Security.OpenId;
using AspNet.Security.OpenId.Steam;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;

namespace IntroTo.OpenIdConnect.Handlers;

public static class Authentication
{
    public static Task OnAuthentication(OpenIdAuthenticatedContext context)
    {
        List<Claim> userClaims = new () {
            new Claim(
                JwtClaimTypes.Subject,
                "steamId",
                ClaimValueTypes.String,
                "https://localhost:3001",
                SteamAuthenticationDefaults.Authority
            )
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