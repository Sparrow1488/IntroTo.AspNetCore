using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _2.UseRunMap
{
    public class Startup
    {
        /*
         * СПРАВКА:
         * ASP.Net состоит из конвееров (middleware), которые содержат определенную логику
         * и могут передавать запрос далее, т.е. другим конвеерам
         * https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/middleware/index/_static/request-delegate-pipeline.png?view=aspnetcore-5.0
         */

        #region Run()
        //public void Configure(IApplicationBuilder app)
        //{
        //    /*
        //    * При создании объекта класса Startup все компоненты middleware создаются один раз
        //    * и сохраняются на протяжении всего жизненного цикла приложения (пока его не выключат).
        //    * Поэтому при обновлении браузера, каждый раз будет выводиться разный результат
        //    */
        //    int res = 2;
        //    /*
        //     * Метод Run вызывает делегат запроса, который обрабатывает ВСЕ запросы.
        //     * Так как данный метод не передает обработку запроса далее по конвейеру, 
        //     * то его следует помещать в самом конце. 
        //     * До него же могут быть помещены другие методы.
        //     */
        //    app.Run(async context =>
        //    {
        //        res *= 2;
        //        await context.Response.WriteAsync("Result: " + res);
        //    });
        //}
        #endregion

        #region Use()
        public void Configure(IApplicationBuilder app)
        {
            int x = 1000;

            /*
             * как и метод Run() добавляет компонент в конвеер, но при этом
             * вызывает следующий по списку компонент middleware
             */
            // первый конвеер middleware
            app.Use(async (context, next) =>
            {
                // logic 1...
                x -= 7;
                await next.Invoke();
            });
            // второй конвеер middleware
            app.Run(async context =>
            {
                // logic 2...
                await context.Response.WriteAsync("RESPONSE : " + x);
            });
            /*
             * ПРИМЕЧАНИЕ: не рекоммендуется отправлять ответ из разных конвееров,
             * поскольку может все поплыть, сломаться и вообще....
             * Ниже пример:
             */
            //#region НЕ РЕКОММЕНДУЕМЫЙ ВАРИАНТ:
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("<p>Hello world!</p>");
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    // await Task.Delay(10000); можно поставить задержку
            //    await context.Response.WriteAsync("<p>Good bye, World...</p>");
            //});
            //#endregion
        }
        #endregion

        #region Map()
        //public void Configure(IApplicationBuilder app)
        //{
        //    /*
        //     * Ну че, тут все понятно: отвечает за подбор делегатов, исходя из запроса
        //     */
        //    app.Map("/home", Home);
        //    // также может иметь вложенности
        //    app.Map("/about", about =>
        //    {
        //        about.Map("/person", AboutPerson);
        //        about.Map("/monkey", AboutMonkey);
        //        about.Run(async context =>
        //        {
        //            await context.Response.WriteAsync("<b>About page. You can visit /about/person/ and /about/monkey</b>");
        //        });
        //    });
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("PLEASE, VISIT OUR /home or /about PAGE");
        //    });
        //}

        //#region ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ
        //private static void Home(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("<b>Home page</b>");
        //    });
        //}
        //private static void AboutPerson(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("<b>About person</b>");
        //    });
        //}
        //private static void AboutMonkey(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("<b>About monkey</b>");
        //    });
        //}
        //#endregion

        #endregion

        #region MapWhen()
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Map("/auth", Auth); //   ./auth/?name="input_name"
        //}
        private void Auth(IApplicationBuilder app)
        {
            /*
             * первый аргумент - условие (возвращает bool)
             * второй - выполняется, если первое условие == true
             */
            app.MapWhen(request =>
            {
                return request.Request.Query.ContainsKey("name") &&
                request.Request.Query["name"] == "Sparrow";
            }, HandledName);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Please, authorizate! (./auth/?name='input_name')");
            });
        }
        private void HandledName(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Cool, u success authorizate!");
            });
        }
        #endregion

    }
}
