namespace Application.BaseUsers.Dtos;

public class RegistrationUserModel : UserModel
{
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = null!;
}