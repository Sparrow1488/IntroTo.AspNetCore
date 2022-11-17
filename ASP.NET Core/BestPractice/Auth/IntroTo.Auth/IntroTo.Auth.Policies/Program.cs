using System.Security.Claims;
using IntroTo.Auth.Policies.Requirements;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeRequirementsHandler>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
        opt.LoginPath = "/login");

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Over18", policyBuilder =>
    {
        policyBuilder.RequireAuthenticatedUser();
        policyBuilder.AddAuthenticationSchemes(CookieAuthenticationDefaults.AuthenticationScheme);
        policyBuilder.AddRequirements(new MinimumAgeRequirements(ageRequired: 18));
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.MapGet("/protect", () => "Adults Only!")
    .RequireAuthorization("Over18");

app.MapGet("/login", async ctx =>
{
    var claims = new[]
    {
        new Claim("usr", "valentin"),
        new Claim("age", "19"),
        // new Claim("age", "17")
    };
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var user = new ClaimsPrincipal(identity);
    await ctx.SignInAsync(user);
    await ctx.Response.WriteAsync("Authenticate success");
});

app.Run();