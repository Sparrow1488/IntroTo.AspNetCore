using FormSender.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FormSender.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNull]DbContextOptions options) : base(options) { }
        public DbSet<MessageForm> MessageForms { get; set; }
    }
}
