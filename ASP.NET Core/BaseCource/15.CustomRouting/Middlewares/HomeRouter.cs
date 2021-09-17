using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _15.CustomRouting.Middlewares
{
    public class HomeRouter : IRouter
    {
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            throw new NotImplementedException();
        }

        public Task RouteAsync(RouteContext context)
        {
            var url = context.HttpContext.Request.Path.Value;

            if (url.ToLower().StartsWith("/home"))
                context.Handler = async httpContext =>
                    await context.HttpContext.Response.WriteAsync(
                        await StaticStorage.GetStaticHtmlAsync("home.html"));
            return Task.CompletedTask;
        }

        


        //  Task.CompletedTask - https://docs.microsoft.com/ru-ru/dotnet/api/system.threading.tasks.task.completedtask?ranMID=46131&ranEAID=a1LgFw09t88&ranSiteID=a1LgFw09t88-RxFB1SrU6mmSNt30N62cMw&epi=a1LgFw09t88-RxFB1SrU6mmSNt30N62cMw&irgwc=1&OCID=AID2200057_aff_7806_1243925&tduid=(ir__tlnovdv9dokfqwari1zc3iv10f2xrutj36l9bmxh00)(7806)(1243925)(a1LgFw09t88-RxFB1SrU6mmSNt30N62cMw)()&irclickid=_tlnovdv9dokfqwari1zc3iv10f2xrutj36l9bmxh00&view=net-5.0

    }
}
