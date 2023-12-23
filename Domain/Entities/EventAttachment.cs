namespace Domain.Entities;

public class EventAttachment : BaseEntity<Guid>
{
    public Guid EventId { get; set; }
    public Event Event { get; set; }
    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; } = null!;
    public string? Content { get; set; }
}