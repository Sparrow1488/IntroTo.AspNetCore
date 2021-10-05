using LearnEnglish.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnEnglish.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<WordsDictionary> Dictionaries { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}
