using Application.BaseModels;
using Application.BaseUsers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/users")]
public class BaseUserController(ISender sender) : BaseController
{
    /// <summary>
    /// Создание пользователя
    /// </summary>
    /// <param name="command">Моедель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CreatedOrUpdatedEntityViewModel> CreateUser([FromQuery] CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}