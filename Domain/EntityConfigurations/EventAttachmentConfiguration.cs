using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class EventAttachmentConfiguration : IEntityTypeConfiguration<EventAttachment>
{
    public void Configure(EntityTypeBuilder<EventAttachment> builder)
    {
        builder.ToTable("event_attachment");
        builder.HasKey(ea => ea.Id);
        builder.Property(ea => ea.Id).IsRequired();

        builder.Property(ea => ea.AttachmentId).IsRequired();
        builder.Property(ea => ea.Content).IsRequired(false);
    }
}