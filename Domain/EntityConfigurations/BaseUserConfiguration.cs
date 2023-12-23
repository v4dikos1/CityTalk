using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

internal class BaseUserConfiguration : IEntityTypeConfiguration<BaseUser>
{
    public void Configure(EntityTypeBuilder<BaseUser> builder)
    {
        builder.ToTable("base_user");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Surname).IsRequired();
        builder.Property(x => x.Patronymic).IsRequired(false);

        builder.Property(x => x.Email).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.PasswordSalt).IsRequired();

        builder.Property(x => x.AttachmentId).IsRequired(false);
        builder.HasOne(x => x.Attachment)
            .WithMany()
            .HasForeignKey(x => x.AttachmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.DateCreated).IsRequired();
        builder.Property(x => x.DateModified).IsRequired();
        builder.Property(x => x.IsArchive).IsRequired();

        builder.HasIndex(u => u.VerificationToken).IsUnique();
        builder.Property(u => u.IsEmailConfirmed).IsRequired();
        builder.Property(x => x.RefreshToken).IsRequired(false);
        builder.Property(x => x.RefreshTokenExpiryTime).IsRequired(false);
    }
}