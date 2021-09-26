using ShoesShop.Entities;
using System.Threading.Tasks;

namespace ShoesShop.Services.Builders
{
    public interface IProductPageBuilder
    {
        public Task<string> BuildHtmlAsync(Product product);
    }
}
