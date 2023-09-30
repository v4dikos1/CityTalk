using Domain.Interfaces;

namespace Domain.Entities;

public class EventCreatorEmployee: BaseEntity<Guid>, IHasArchiveAttribute, IHasTrackDateAttribute
{
    public Guid BaseUseId { get; set; }
    public BaseUser BaseUser { get; set; } = null!;
    public Guid EventCreatorId { get; set; }
    public EventCreator EventCreator { get; set; } = null!;
    public bool IsArchive { get; set; }
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}