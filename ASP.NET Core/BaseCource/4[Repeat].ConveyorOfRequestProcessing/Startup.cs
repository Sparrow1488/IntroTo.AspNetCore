using _3_Repeat_.CreateMiddleware.Middlewares;
using _4_Repeat_.ConveyorOfRequestProcessing.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4_Repeat_.ConveyorOfRequestProcessing
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseMiddleware<RoutingMiddleware>();
            app.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
