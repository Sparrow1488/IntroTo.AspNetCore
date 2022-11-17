using System.Security.Claims;
using IntroTo.Auth.Schemas.Handlers;
using IntroTo.Auth.Schemas.Schemas;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(ApiSchemas.AnonAuthenticationSchema)
    .AddCookie(ApiSchemas.AnonAuthenticationSchema, opt =>
    {
        opt.LoginPath = "/login-anon";
        opt.Cookie.Name = "auth.anonymous";
    })
    .AddScheme<CookieAuthenticationOptions, LocalAuthenticationHandler>(
        ApiSchemas.LocalAuthenticationSchema, 
        opt =>
        {
            opt.Cookie.Name = "auth.local";
        });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("NamedUser", policyBuilder =>
    {
        policyBuilder.RequireAuthenticatedUser();
        policyBuilder.AddAuthenticationSchemes(ApiSchemas.LocalAuthenticationSchema);
        policyBuilder.RequireClaim(ClaimTypes.Name);
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!").RequireAuthorization();

app.MapGet("/me", async ctx =>
{
    var nameClaim = ctx.User.FindFirst(ClaimTypes.Name);
    var name = nameClaim?.Value;
    await ctx.Response.WriteAsync($"Hello, {name}!");
}).RequireAuthorization("NamedUser");

app.MapGet("/login-anon", async ctx =>
{
    var claims = new[] { new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()) };
    var identity = new ClaimsIdentity(claims, ApiSchemas.AnonAuthenticationSchema);
    var user = new ClaimsPrincipal(identity);
    await ctx.SignInAsync(ApiSchemas.AnonAuthenticationSchema, user);
});

app.Run();