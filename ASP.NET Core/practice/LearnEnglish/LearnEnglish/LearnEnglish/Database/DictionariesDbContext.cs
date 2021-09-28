using LearnEnglish.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnEnglish.Database
{
    public class DictionariesDbContext : DbContext
    {
        public DictionariesDbContext(DbContextOptions options) : base(options) { }
        public DbSet<WordsDictionary> Dictionaries { get; set; }
    }
}
