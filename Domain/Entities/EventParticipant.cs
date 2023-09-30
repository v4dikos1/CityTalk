using Domain.Interfaces;

namespace Domain.Entities;

public class EventParticipant : BaseEntity<Guid>, IHasArchiveAttribute, IHasTrackDateAttribute
{
    public Guid BaseUserId { get; set; }
    public BaseUser BaseUser { get; set; } = null!;
    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;
    public int Evaluation { get; set; }
    public int EventCreatorEvaluation { get; set; }
    public bool IsArchive { get; set; }
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}