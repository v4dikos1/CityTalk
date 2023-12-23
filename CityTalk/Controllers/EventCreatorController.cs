using Application.BaseModels;
using Application.EventCreators.Commands;
using Application.EventCreators.Dtos;
using Application.EventCreators.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/event-creators")]
[Authorize]
public class EventCreatorController(ISender sender) : BaseController
{
    /// <summary>
    /// Создание агрегатора мероприятий
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CreatedOrUpdatedEntityViewModel> CreateEventCreator([FromQuery] CreateEventCreatorCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Получение профиля агрегатора мероприятий
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<EventCreatorViewModel> GetEventCreator([FromQuery] GetEventCreatorQuery query,
        CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}