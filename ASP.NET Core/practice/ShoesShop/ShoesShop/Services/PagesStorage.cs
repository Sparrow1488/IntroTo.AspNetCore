using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.Services
{
    public class PagesStorage : IPagesStorage
    {
        public async Task<string> GetHtmlAsync(string path)
        {
            var builder = new StringBuilder();
            using (var sr = new StreamReader("wwwroot/" + path))
                builder.Append(await sr.ReadToEndAsync());
            return builder.ToString();
        }
    }
}
