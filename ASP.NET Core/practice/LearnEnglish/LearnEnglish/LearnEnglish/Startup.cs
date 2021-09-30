using LearnEnglish.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnEnglish
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => UseSqlServer(options));

            //services.AddDbContext<DictionariesDbContext>(options => UseSqlServer(options));
            //services.AddDbContext<ProfilesDbContext>(options => UseSqlServer(options));
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private DbContextOptionsBuilder UseSqlServer(DbContextOptionsBuilder builder)
        {
            return builder.UseSqlServer(Configuration.GetConnectionString("BaseConnection"));
        }
    }
}
