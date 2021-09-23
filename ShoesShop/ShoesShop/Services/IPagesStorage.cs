using System.Threading.Tasks;

namespace ShoesShop.Services
{
    public interface IPagesStorage
    {
        public Task<string> GetHtmlAsync(string path);
    }
}
