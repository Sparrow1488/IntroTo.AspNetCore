using Microsoft.AspNetCore.Builder;

namespace _6_Repeat_.StaticFiles
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear(); // очищаем, чтобы index and default файлы не воспринимались
            options.DefaultFileNames.Add("uniqueName.html");

            app.UseDefaultFiles(options);
            app.UseStaticFiles();
        }
    }
}
