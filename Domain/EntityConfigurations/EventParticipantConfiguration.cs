using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class EventParticipantConfiguration : IEntityTypeConfiguration<EventParticipant>
{
    public void Configure(EntityTypeBuilder<EventParticipant> builder)
    {
        builder.ToTable("event_participant");
        builder.HasKey(ep => ep.Id);
        builder.Property(ep => ep.Id).IsRequired();

        builder.Property(ep => ep.BaseUserId).IsRequired();
        builder.Property(ep => ep.EventId).IsRequired();
        builder.Property(ep => ep.Evaluation).IsRequired();
        builder.Property(ep => ep.EventCreatorEvaluation).IsRequired();
        builder.Property(ep => ep.IsArchive).IsRequired();
        builder.Property(ep => ep.DateCreated).IsRequired();
        builder.Property(ep => ep.DateModified).IsRequired();
    }
}