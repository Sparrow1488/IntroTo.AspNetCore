using FormSender.Entities;
using FormSender.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FormSender.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNull]DbContextOptions options) : base(options) { }
        public DbSet<MessageForm> MessageForms { get; set; }
        public DbSet<WebDocument> Documents { get; set; }
        public DbSet<Content> Content { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Startup).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
