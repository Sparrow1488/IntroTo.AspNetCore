using Microsoft.AspNetCore.Http;
using ShoesShop.Entities;
using ShoesShop.Services.Builders;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesShop.Middlewares
{
    public class ProductsMiddleware : Middleware
    {
        private readonly IProductPageBuilder _pageBuilder;
        private Product[] Products =
        {
            new Shoes(){ Key = 1, Name = "Nike Air Max 1 Nike Air Max 1/97 Sean Wotherspoon Sean Wotherspoon", Price = 139.99, Description = @"Lorem ipsum dolor sit amet consectetur adipisicing elit. Nesciunt, libero! Officiis, sunt nostrum quaerat expedita explicabo necessitatibus nam aperiam officia! Saepe nostrum deleniti odio. Ea.", Images = new string[] { @"https://ae01.alicdn.com/kf/HTB1jNRIXsfrK1Rjy1Xdq6yemFXau/Original-aut%C3%A9ntico-Nike-Air-Max-1-97-VF-SW-para-hombre-zapatillas-de-deporte-Zapatillas-de.jpg", @"https://static.cloud-boxloja.com/lojas/i3zzh/produtos/4c35fe6f-ce44-4fd8-8581-a1dd8257719e.jpg", @"https://static.street-beat.ru/upload/resize_cache/iblock/b0f/500_500_1/b0fc141e609738928c22df87767829bd.jpg" } },
            new Shoes(){ Key = 2, Name = "Nike Air Max 3 Plus", Price = 499.99, Description = @"Lorem ipsum, dolor sit amet consectetur adipisicing elit. Placeat ducimus dignissimos consequuntur doloremque vitae at sed magni ipsam ipsum? Autem earum suscipit ad quae, optio ab delectus quod velit blanditiis culpa nostrum. Doloremque obcaecati ipsum debitis porro atque repellendus laborum quibusdam tempore quidem facilis dolor aliquid quod voluptates aut ab, fugit corrupti deserunt illum omnis necessitatibus, corporis nemo! Veniam ratione error tempora cupiditate? Voluptate obcaecati non animi omnis nesciunt excepturi deleniti enim porro nam voluptatibus explicabo quas, perferendis corporis expedita culpa asperiores sequi quaerat atque dolorum veritatis. Possimus nihil porro, iste in beatae iusto aliquam?", Images = new string[] { @"https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/1d9d6465-6f7e-4d42-bfb0-116e09f10f13/%D0%BA%D1%80%D0%BE%D1%81%D1%81%D0%BE%D0%B2%D0%BA%D0%B8-air-max-plus-tw0JNP.png", @"https://static.nike.com/a/images/t_default/1adf66a7-6af8-4603-b661-e310b5290b76/%D0%BA%D1%80%D0%BE%D1%81%D1%81%D0%BE%D0%B2%D0%BA%D0%B8-air-max-plus-3-6jrtM9.png", @"https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/5611cb33-f048-40c3-9697-dcb3a397cadf/%D0%BA%D1%80%D0%BE%D1%81%D1%81%D0%BE%D0%B2%D0%BA%D0%B8-air-max-plus-3-6jrtM9.png" } },
        };

        public ProductsMiddleware(RequestDelegate next, IProductPageBuilder pageBuilder) : base(next)
        {
            _next = next;
            _pageBuilder = pageBuilder;
        }
        public ProductsMiddleware(RequestDelegate next) : base(next) { }
       
        public override async Task InvokeAsync(HttpContext context)
        {
            string html = string.Empty;
            var product = SelectProductByQuery(context.Request.Query);
            if (product is not EmptyProduct && product is not null)
            {
                html = await _pageBuilder.BuildHtmlAsync(product);
                await context.Response.WriteAsync(html);
            }
            else await _next.Invoke(context);
        }
        private Product SelectProductByQuery(IQueryCollection query)
        {
            Product product = new EmptyProduct();
            bool correctProductId = query.TryGetValue("product", out var value);
            var validQuery = int.TryParse(value, out var prodId);
            if (validQuery)
                product = Products.Where(shoes => shoes.Key == prodId).FirstOrDefault();
            return product;
        }
    }
}
