using Microsoft.AspNetCore.Http;

namespace Application.Abstractions;

public interface ICurrentHttpContextAccessor
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string? UserPatronymic { get; set; }
    void SetContext(HttpContext context);
}