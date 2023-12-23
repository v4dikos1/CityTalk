using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("message");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).IsRequired();

        builder.Property(m => m.SenderId).IsRequired();
        builder.Property(m => m.ReceiverId).IsRequired();
        builder.Property(m => m.Content).IsRequired();
        builder.Property(m => m.IsRead).IsRequired();
        builder.Property(m => m.IsArchive).IsRequired();
        builder.Property(m => m.DateCreated).IsRequired();
        builder.Property(m => m.DateModified).IsRequired();

        builder.HasMany(m => m.Attachments)
            .WithOne(x => x.Message)
            .HasForeignKey(ma => ma.MessageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}