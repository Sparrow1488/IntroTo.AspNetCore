using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Http;
using ShoesShop.Services;
using System.IO;
using System.Threading.Tasks;

namespace ShoesShop.Middlewares
{
    public class ProductsMiddleware : Middleware
    {
        private readonly IPagesStorage _storage;
        private string _outHtml = string.Empty;

        public ProductsMiddleware(RequestDelegate next, IPagesStorage pagesStorage) : base(next)
        {
            _next = next;
            _storage = pagesStorage;
        }
        public ProductsMiddleware(RequestDelegate next) : base(next) { }
       
        public override async Task InvokeAsync(HttpContext context)
        {
            int productId = GetProductId(context);
            _outHtml = await _storage.GetHtmlAsync("index.html");
            _outHtml = await PrepareProductData(productId);

            if (string.IsNullOrWhiteSpace(_outHtml))
                await _next.Invoke(context);

            await context.Response.WriteAsync(_outHtml);
        }
        private async Task<string> PrepareProductData(int productId)
        {
            string html = string.Empty;
            if (productId < 1)
                return _outHtml;

            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(_outHtml);
            var element = document.QuerySelector(".slider-images__row");
            element.InnerHtml = "<div></div>";
            html = document.DocumentElement.OuterHtml;
            return html;
        }
        private int GetProductId(HttpContext context)
        {
            bool correctProductId = context.Request.Query.TryGetValue("product", out var value);
            int id = 0;
            if (correctProductId)
                id = int.Parse(value.ToString());
            return id;
        }
    }
}
