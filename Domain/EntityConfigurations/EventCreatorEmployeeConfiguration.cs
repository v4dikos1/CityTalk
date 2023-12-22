using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.EntityConfigurations;

internal class EventCreatorEmployeeConfiguration : IEntityTypeConfiguration<EventCreatorEmployee>
{
    public void Configure(EntityTypeBuilder<EventCreatorEmployee> builder)
    {
        builder.ToTable("event_creator_employee");
        builder.HasKey(ece => ece.Id);
        builder.Property(ece => ece.Id).IsRequired();

        builder.Property(ece => ece.BaseUseId).IsRequired();
        builder.Property(ece => ece.EventCreatorId).IsRequired();
        builder.Property(ece => ece.IsArchive).IsRequired();
        builder.Property(ece => ece.DateCreated).IsRequired();
        builder.Property(ece => ece.DateModified).IsRequired();
    }
}