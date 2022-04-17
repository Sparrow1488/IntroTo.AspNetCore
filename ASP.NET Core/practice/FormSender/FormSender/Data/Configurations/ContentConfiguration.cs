using FormSender.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormSender.Data.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Content");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Text).HasMaxLength(350).IsRequired();
            builder.HasMany(x => x.Documents)
                   .WithOne(x => x.Content)
                   .HasForeignKey(x => x.Id);
        }
    }
}
