using IdentityServer4;
using IntroTo.OpenIdConnect.Configurations;
using IntroTo.OpenIdConnect.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer(options => {
        options.UserInteraction.LoginUrl = "/authentication/login";
        // Optional
        options.Authentication.CookieLifetime = TimeSpan.FromMinutes(10);
        options.Authentication.CookieSlidingExpiration = true;
        options.Authentication.CookieSameSiteMode = SameSiteMode.Lax;
    })
    .AddInMemoryIdentityResources(IdentityConfiguration.GetIdentityResources())
    .AddInMemoryClients(IdentityConfiguration.GetClients())
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication(IdentityServerConstants.DefaultCookieAuthenticationScheme)
    .AddSteam(options => {
       options.SignInScheme = IdentityServerConstants.DefaultCookieAuthenticationScheme;
       options.ApplicationKey = "secret";
       options.Events.OnAuthenticated += Authentication.OnAuthentication;
    });

builder.Services.Configure<RouteOptions>(x => {
    x.LowercaseUrls = true;
    x.LowercaseQueryStrings = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();