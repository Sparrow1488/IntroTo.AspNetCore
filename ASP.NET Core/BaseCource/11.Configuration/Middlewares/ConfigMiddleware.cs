using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace _11.Configuration.Middlewares
{
    public class ConfigMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _appConfig;

        public ConfigMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _appConfig = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_appConfig != null)
            {
                var txtSets = new TextSettings();
                _appConfig.Bind(txtSets);
                var txtSettings = _appConfig.Get<TextSettings>();
                var authorSection = _appConfig.GetSection("author");
                var appSection = _appConfig.GetSection("application");
                // в JSON (как и XML), можно использовать большую вложенность, главное - указывать путь до значения через двоеточие и ключи
                await context.Response.WriteAsync($"<p style='color:{txtSettings.Color};'>{txtSettings.Text}</p>" +
                    $"<br>" +
                    $"<p>Author: {_appConfig["author:name"]}</p>" +
                    $"<p>Rating: {authorSection["rating"]}</p>" +
                    $"<p>Application: {_appConfig["application:title"]}</p>" +
                    $"<p>Status: {appSection["status"]}</p>" +
                    $"<p>Date create: {_appConfig["dateCreate"]}</p>");
            }
            else await _next.Invoke(context);
        }

        // хороший пример с рефлексией
        private string GetSectionContent(IConfiguration configSection)
        {
            string sectionContent = "";
            foreach (var section in configSection.GetChildren())
            {
                sectionContent += "\"" + section.Key + "\":";
                if (section.Value == null)
                {
                    string subSectionContent = GetSectionContent(section);
                    sectionContent += "{\n" + subSectionContent + "},\n";
                }
                else sectionContent += "\"" + section.Value + "\",\n";
            }
            return sectionContent;
        }
    }
}
