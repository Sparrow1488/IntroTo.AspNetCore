using _2.DbWork.Models;
using Microsoft.EntityFrameworkCore;

namespace _2.DbWork.Database
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
    }
}
