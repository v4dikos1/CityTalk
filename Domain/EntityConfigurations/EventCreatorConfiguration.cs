using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class EventCreatorConfiguration : IEntityTypeConfiguration<EventCreator>
{
    public void Configure(EntityTypeBuilder<EventCreator> builder)
    {
        builder.ToTable("event_creator");
        builder.HasKey(ec => ec.Id);
        builder.Property(ec => ec.Id).IsRequired();

        builder.Property(ec => ec.OwnerId).IsRequired();
        builder.Property(ec => ec.Name).IsRequired();
        builder.Property(ec => ec.Description).IsRequired(false);
        builder.Property(ec => ec.IsArchive).IsRequired();
        builder.Property(ec => ec.DateCreated).IsRequired();
        builder.Property(ec => ec.DateModified).IsRequired();

        builder.HasMany(ec => ec.Events)
            .WithOne(x => x.Creator)
            .HasForeignKey(e => e.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(ec => ec.Employees)
            .WithOne(x => x.EventCreator)
            .HasForeignKey(ece => ece.EventCreatorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}