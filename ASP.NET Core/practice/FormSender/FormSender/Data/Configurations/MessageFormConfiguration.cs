using FormSender.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FormSender.Data.Configurations
{
    public class MessageFormConfiguration : IEntityTypeConfiguration<MessageForm>
    {
        public void Configure(EntityTypeBuilder<MessageForm> builder)
        {
            builder.ToTable("MessageForms");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.DateUpdated);
            builder.HasOne(x => x.Content)
                   .WithOne(x => x.MessageForm)
                   .HasForeignKey<Content>(x => x.Id)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
