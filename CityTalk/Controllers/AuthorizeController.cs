using Application.BaseModels;
using Application.BaseUsers.Commands;
using Application.BaseUsers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AuthorizeController(ISender sender) : BaseController
{
    /// <summary>
    /// Логин в приложении
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("authorize")]
    public async Task<UserAuthorizationSuccessModel> Authorize([FromQuery] AuthorizeBaseUserCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Подтверждение почты
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("confirm-email")]
    public async Task<EmptyViewModel> ConfirmEmail([FromQuery] ConfirmEmailCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}