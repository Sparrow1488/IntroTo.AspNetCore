using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _15.CustomRouting
{
    public static class StaticStorage
    {
        public static async Task<string> GetStaticHtmlAsync(string name)
        {
            var builder = new StringBuilder();
            using (var sr = new StreamReader("wwwroot/" + name))
                builder.Append(await sr.ReadToEndAsync());
            return builder.ToString();
        }
    }
}
