using Application.BaseModels;
using Application.Events.Commands;
using Application.Events.Dtos;
using Application.Events.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/event-creators/{EventCreatorId}/events")]
public class EventController(ISender sender) : BaseController
{
    /// <summary>
    /// Создание мероприятия
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CreatedOrUpdatedEntityViewModel> CreateEvent([FromQuery] CreateEventCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Получение списка всех мероприятий агрегатора
    /// </summary>
    /// <param name="query">Модель запроса</param>
    /// <param name="cancellation">Токен отмены</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<EventListViewModel>> GetEvents([FromQuery] GetEventsListQuery query,
        CancellationToken cancellation)
    {
        return await sender.Send(query, cancellation);
    }

    /// <summary>
    /// Архивация мероприятия
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpDelete("{EventId}")]
    public async Task<EmptyViewModel> ArchiveEvent([FromQuery] ArchiveEventCommand command,
        CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}