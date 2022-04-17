using FormSender.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormSender.Data.Configurations
{
    public class WebDocumentsConfiguration : IEntityTypeConfiguration<WebDocument>
    {
        public void Configure(EntityTypeBuilder<WebDocument> builder)
        {
            builder.ToTable("Documents");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Extension).HasMaxLength(10);
            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}
