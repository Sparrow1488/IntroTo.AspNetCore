using _2.DbWork.Models;
using Microsoft.EntityFrameworkCore;

namespace _2.DbWork.Database
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
