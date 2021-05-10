using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BaseCource
{
    /*
     * ќбработка запроса в ASP.NET Core устроена по принципу конвейера. 
     * —начала данные запроса получает первый компонент в конвейере, а после обработки он передает данные HTTP-запроса второму компоненту и так далее. 
     * Ёти компоненты конвейера, которые отвечают за обработку запроса, называютс€ middleware. 
     * ¬ ASP.NET Core дл€ подключени€ компонентов middleware используетс€ метод Configure из класса Startup.
     */
    public class Startup
    {
        private IWebHostEnvironment _environment;
        // дл€ Empty проекта, конструктор в классе Startup может отсутсовать, однако его можно создать вручную
        // и при инициализации (т.е. начальной конфигурации) использовать что угодно
        public Startup(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // метод, который позвол€ет подключать различные сервисы (не об€зателен)
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // устанавливает, как приложение будет обрабатывать запрос (об€зательный)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // если приложение в разработке, то выводим такую то инфу
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // добавл€ем возможности маршрутизации (и производим все настройки дл€ этого)
            app.UseRouting();

            // устанавливаем адреса, которые будут обрабатыватьс€
            app.UseEndpoints(endpoints =>
            {
                // указывает, что при обращении по запросу "/" (корневой папке) ...
                endpoints.MapGet("/", async context =>
                {
                    // будет выводитьс€ следующее:
                    await context.Response.WriteAsync("Hello ASP.NET Core 5!");
                });
                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync($"Application use : {_environment.ApplicationName}");
                });
            });

            // обработает все запросы, которые не были обработаны ранее (но о нем далее)
            app.Run(async context =>
            {
                await context.Response.WriteAsync("We can't processing your request!!!!!!!");
            });
        }
    }
}
