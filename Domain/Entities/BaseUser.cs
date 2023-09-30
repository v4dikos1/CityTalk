using Domain.Interfaces;

namespace Domain.Entities;

public class BaseUser : BaseEntity<Guid>, IHasArchiveAttribute, IHasTrackDateAttribute
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Patronymic { get; set; }
    public string? Nickname { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public Guid? AttachmentId { get; set; }
    public Attachment? Attachment { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsArchive { get; set; }
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}