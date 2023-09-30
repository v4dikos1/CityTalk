using Domain.Interfaces;

namespace Domain.Entities;

public class EventCreator : BaseEntity<Guid>, IHasArchiveAttribute, IHasTrackDateAttribute
{
    public Guid OwnerId { get; set; }
    public BaseUser Owner { get; set; } = null!;
    public ICollection<Event> Events { get; set; } = new List<Event>();
    public ICollection<EventCreatorEmployee> Employees { get; set; } = new List<EventCreatorEmployee>();
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsArchive { get; set; }
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}