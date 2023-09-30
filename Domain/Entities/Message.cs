using Domain.Interfaces;

namespace Domain.Entities;

public class Message : BaseEntity<Guid>, IHasTrackDateAttribute, IHasArchiveAttribute
{
    public Guid SenderId { get; set; }
    public BaseUser Sender { get; set; } = null!;
    public Guid ReceiverId { get; set; }
    public BaseUser Receiver { get; set; } = null!;
    public string Content { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public ICollection<MessageAttachment> Attachments { get; set; } = new List<MessageAttachment>();
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public bool IsArchive { get; set; }
}