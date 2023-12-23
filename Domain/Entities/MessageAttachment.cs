namespace Domain.Entities;

public class MessageAttachment : BaseEntity<Guid>
{
    public Guid MessageId { get; set; }
    public Message Message { get; set; }

    public Guid AttachmentId { get; set; }
    public Attachment Attachment { get; set; }

    public string Content { get; set; }
}