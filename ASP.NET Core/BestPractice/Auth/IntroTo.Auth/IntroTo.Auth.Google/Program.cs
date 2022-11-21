using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddGoogle(options =>
                {
                    options.ClientId = builder.Configuration["Auth:Google:ClientId"];
                    options.ClientSecret = builder.Configuration["Auth:Google:ClientSecret"];
                    options.Events.OnCreatingTicket += ticket =>
                    {
                        ticket?.Identity?.AddClaim(
                            new Claim(
                                ClaimTypes.Role, 
                                "permissions.roles.user"));
                        return Task.CompletedTask;
                    };
                });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("login", async (ctx) =>
{
    var redirectUri = ctx.Request.Query["redirectUri"].ToString();
    var properties = new AuthenticationProperties 
    { 
        RedirectUri = string.IsNullOrWhiteSpace(redirectUri) ? "/me" : redirectUri,
        AllowRefresh = true,
        IsPersistent = true 
    };
    await ctx.ChallengeAsync(GoogleDefaults.AuthenticationScheme, properties);
});

app.MapGet("me", async ctx =>
{
    var claims = ctx.User.Claims.Select(x => $"{x.Type}: {x.Value}");
    await ctx.Response.WriteAsJsonAsync(claims);
}).RequireAuthorization();

app.MapControllers();

app.Run();
