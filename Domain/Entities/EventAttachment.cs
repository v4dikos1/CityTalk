namespace Domain.Entities;

public class EventAttachment
{
    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; } = null!;
    public string? Content { get; set; }
}