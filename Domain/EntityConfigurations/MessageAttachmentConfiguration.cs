using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class MessageAttachmentConfiguration : IEntityTypeConfiguration<MessageAttachment>
{
    public void Configure(EntityTypeBuilder<MessageAttachment> builder)
    {
        builder.ToTable("message_attachment");
        builder.HasKey(ma => ma.Id);
        builder.Property(ma => ma.Id).IsRequired();

        builder.Property(ma => ma.MessageId).IsRequired();
        builder.Property(ma => ma.AttachmentId).IsRequired();
        builder.Property(ma => ma.Content).IsRequired();
    }
}