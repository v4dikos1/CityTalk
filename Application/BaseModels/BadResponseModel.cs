namespace Application.BaseModels;

/// <summary>
///     Модель тела ошибки
/// </summary>
public class BadResponseModel
{
    /// <summary>
    ///     Сообщение об ошибке от сервера
    /// </summary>
    public string Message { get; set; } = string.Empty;
}