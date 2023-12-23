namespace Application.BaseUsers.Dtos;

public class LoginBaseUserModel
{
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = string.Empty;
}