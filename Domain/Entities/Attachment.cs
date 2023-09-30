using Domain.Interfaces;

namespace Domain.Entities;

public class Attachment : BaseEntity<Guid>, IHasArchiveAttribute, IHasTrackDateAttribute
{
    public string Path { get; set; } = null!;
    public bool IsArchive { get; set; }
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}