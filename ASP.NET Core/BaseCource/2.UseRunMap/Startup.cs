using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace _2.UseRunMap
{
    public class Startup
    {
        /*
         * �������:
         * ASP.Net ������� �� ��������� (middleware), ������� �������� ������������ ������
         * � ����� ���������� ������ �����, �.�. ������ ���������
         * https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/middleware/index/_static/request-delegate-pipeline.png?view=aspnetcore-5.0
         */

        #region Run()
        //public void Configure(IApplicationBuilder app)
        //{
        //    /*
        //    * ��� �������� ������� ������ Startup ��� ���������� middleware ��������� ���� ���
        //    * � ����������� �� ���������� ����� ���������� ����� ���������� (���� ��� �� ��������).
        //    * ������� ��� ���������� ��������, ������ ��� ����� ���������� ������ ���������
        //    */
        //    int res = 2;
        //    /*
        //     * ����� Run �������� ������� �������, ������� ������������ ��� �������.
        //     * ��� ��� ������ ����� �� �������� ��������� ������� ����� �� ���������, 
        //     * �� ��� ������� �������� � ����� �����. 
        //     * �� ���� �� ����� ���� �������� ������ ������.
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
             * ��� � ����� Run() ��������� ��������� � �������, �� ��� ����
             * �������� ��������� �� ������ ��������� middleware
             */
            // ������ ������� middleware
            app.Use(async (context, next) =>
            {
                // logic 1...
                x -= 7;
                await next.Invoke();
            });
            // ������ ������� middleware
            app.Run(async context =>
            {
                // logic 2...
                await context.Response.WriteAsync("RESPONSE : " + x);
            });
            /*
             * ����������: �� �������������� ���������� ����� �� ������ ���������,
             * ��������� ����� ��� �������, ��������� � ������....
             * ���� ������:
             */
            //#region �� �������������� �������:
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("<p>Hello world!</p>");
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    // await Task.Delay(10000); ����� ��������� ��������
            //    await context.Response.WriteAsync("<p>Good bye, World...</p>");
            //});
            //#endregion
        }
        #endregion

        #region Map()
        //public void Configure(IApplicationBuilder app)
        //{
        //    /*
        //     * �� ��, ��� ��� �������: �������� �� ������ ���������, ������ �� �������
        //     */
        //    app.Map("/home", Home);
        //    // ����� ����� ����� �����������
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

        //#region ��������������� ������
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
             * ������ �������� - ������� (���������� bool)
             * ������ - �����������, ���� ������ ������� == true
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
