using AngleSharp.Html.Parser;
using ShoesShop.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.Services.Builders
{
    public class ProductPageBuilder : IProductPageBuilder
    {
        private IPagesStorage _pagesStorage;
        public ProductPageBuilder(IPagesStorage pagesStorage)
        {
            _pagesStorage = pagesStorage;
        }

        public async Task<string> BuildHtmlAsync(Product product)
        {
            var parser = new HtmlParser();
            var emptyHtml = await _pagesStorage.GetHtmlAsync("index.html");
            var document = await parser.ParseDocumentAsync(emptyHtml);

            var currentImg = document.QuerySelector(".slider__current-image");
            var sliderImages = document.QuerySelector(".slider-images__row");
            var title = document.QuerySelector(".product-title");
            var desc = document.QuerySelector(".desc-block__text");
            var price = document.QuerySelector(".product-price");

            currentImg.InnerHtml = BuildCurrentImage(product.Images);
            sliderImages.InnerHtml = BuildImages(product.Images);
            title.InnerHtml = product.Name;
            desc.InnerHtml = BuildDescription(product.Description);
            price.InnerHtml = BuildPrice(product.Price);

            return document.DocumentElement.OuterHtml;
        }
        private string BuildCurrentImage(string[] links)
        {
            string emptyImageLink = @"https://upload.wikimedia.org/wikipedia/commons/thumb/1/15/No_image_available_600_x_450.svg/600px-No_image_available_600_x_450.svg.png";
            string link = links == null || links.Length == 0 ? emptyImageLink : links[0];
            return $"<img src=\"{link}\" alt=\"product\">";
        }
        private string BuildImages(string[] links)
        {
            var imagesBuilder = new StringBuilder("");
            if (links != null)
                links.ToList().ForEach(link => imagesBuilder
                                                                    .Append($"<img class=\"slider-image\" src=\"{link}\" alt=\"\">\n"));
            return imagesBuilder.ToString();
        }
        private string BuildDescription(string text)
        {
            return $"<p class=\"text\">{text}</p>";
        }
        private string BuildPrice(double price)
        {
            return $"<h3 class=\"title\">{price}$</h3>";
        }

    }
}
