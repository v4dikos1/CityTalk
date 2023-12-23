using System.Security.Claims;
using Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure;

public class CurrentHttpContextAccessor : ICurrentHttpContextAccessor
{
    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string UserSurname { get; set; } = null!;
    public string? UserPatronymic { get; set; }

    public void SetContext(HttpContext context)
    {
        if (!string.IsNullOrEmpty(UserId))
        {
            return;
        }
        var user = context.User;
        UserId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value!;
        UserName = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value!;
        UserSurname = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value!;
        UserPatronymic = user.Claims.FirstOrDefault(x => x.Type == "Patronymic")?.Value;
    }

}