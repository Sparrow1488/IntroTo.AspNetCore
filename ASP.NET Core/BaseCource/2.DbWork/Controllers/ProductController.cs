using _2.DbWork.Database;
using _2.DbWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _2.DbWork.Controllers
{
    [Route("/product")]
    public class ProductController : Controller
    {
        private readonly ProductsDbContext _db;

        public ProductController(ProductsDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> allProducts = _db.Products;
            return View(allProducts);
        }
    }
}
