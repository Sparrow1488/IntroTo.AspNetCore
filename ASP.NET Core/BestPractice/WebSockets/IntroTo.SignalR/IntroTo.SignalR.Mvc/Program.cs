using IntroTo.SignalR.Mvc.Hubs;
using IntroTo.SignalR.Mvc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<UserManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapGet("/", ctx =>
{
    ctx.Response.Redirect("/chat.html");
    return Task.CompletedTask;
});

app.MapHub<ChatHub>("/chat");

app.MapControllers();

app.Run();