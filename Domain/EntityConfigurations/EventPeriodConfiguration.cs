using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class EventPeriodConfiguration : IEntityTypeConfiguration<EventPeriod>
{
    public void Configure(EntityTypeBuilder<EventPeriod> builder)
    {
        builder.ToTable("event_period");
        builder.HasKey(ep => ep.Id);
        builder.Property(ep => ep.Id).IsRequired();

        builder.Property(ep => ep.DayOfWeek).IsRequired();
        builder.Property(ep => ep.EventId).IsRequired();
        builder.Property(ep => ep.StartDate).IsRequired();
        builder.Property(ep => ep.EndDate).IsRequired();
        builder.Property(ep => ep.IsArchive).IsRequired();
        builder.Property(ep => ep.DateCreated).IsRequired();
        builder.Property(ep => ep.DateModified).IsRequired();
    }
}