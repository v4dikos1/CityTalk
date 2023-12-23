using Domain.Entities.Json;
using Domain.Interfaces;

namespace Domain.Entities;

public class Event : BaseEntity<Guid>, IHasArchiveAttribute, IHasTrackDateAttribute
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Address Address { get; set; } = null!;
    public string? Coordinates { get; set; } = null!;
    public Guid CreatorId { get; set; }
    public EventCreator Creator { get; set; } = null!;
    public ICollection<EventParticipant> Participants { get; set; } = new List<EventParticipant>();
    public ICollection<EventPeriod> Periods { get; set; } = new List<EventPeriod>();
    public ICollection<EventAttachment> Attachments { get; set; } = new List<EventAttachment>();
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset? EndDate { get; set; }
    public bool IsPeriodic { get; set; }
    public bool IsArchive { get; set; }
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}