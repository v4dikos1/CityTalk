using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("attachment");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).IsRequired();

        builder.Property(a => a.Path).IsRequired();
        builder.HasIndex(a => a.Path).IsUnique();

        builder.Property(a => a.IsArchive).IsRequired();
        builder.Property(a => a.DateCreated).IsRequired();
        builder.Property(a => a.DateModified).IsRequired();
    }
}