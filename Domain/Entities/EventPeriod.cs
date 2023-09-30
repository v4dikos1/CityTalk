using Domain.Entities.Enums;
using Domain.Interfaces;

namespace Domain.Entities;

public class EventPeriod : BaseEntity<Guid>, IHasArchiveAttribute, IHasTrackDateAttribute
{
    public DayOfWeekEnum DayOfWeek { get; set; }
    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public bool IsArchive { get; set; }
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}