using Microsoft.AspNetCore.Builder;

namespace _6_Repeat_.StaticFiles
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear(); // �������, ����� index and default ����� �� ��������������
            options.DefaultFileNames.Add("uniqueName.html");

            app.UseDefaultFiles(options);
            app.UseStaticFiles();
        }
    }
}
