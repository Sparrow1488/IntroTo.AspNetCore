using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(config =>
{
    config.Configuration = "127.0.0.1:6379";
});

var app = builder.Build();

app.MapGet("/", (IDistributedCache cache) =>
{
    cache.SetString("cat", "Meow");
});

app.MapGet("/value", async (IDistributedCache cache, HttpContext ctx) =>
{
    var dog = await cache.GetStringAsync("cat");
    await ctx.Response.WriteAsync(dog);
});

app.Run();