using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("event");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).IsRequired();

        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.Address).IsRequired().HasColumnType("jsonb");
        builder.Property(e => e.Coordinates).IsRequired();
        builder.Property(e => e.CreatorId).IsRequired();
        builder.Property(e => e.StartDate).IsRequired();
        builder.Property(e => e.EndDate).IsRequired();
        builder.Property(e => e.IsPeriodic).IsRequired();
        builder.Property(e => e.IsArchive).IsRequired();
        builder.Property(e => e.DateCreated).IsRequired();
        builder.Property(e => e.DateModified).IsRequired();

        builder.HasMany(e => e.Participants)
            .WithOne(p => p.Event)
            .HasForeignKey(ep => ep.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Periods)
            .WithOne(x => x.Event)
            .HasForeignKey(ep => ep.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.Attachments)
            .WithOne(x => x.Event)
            .HasForeignKey(ea => ea.EventId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}