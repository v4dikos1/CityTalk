namespace Domain.Interfaces;

public interface IHasTrackDateAttribute
{
    public DateTimeOffset DateModified { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}