using Application.Events.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Events.Queries;

public class GetEventsListQuery : IRequest<IEnumerable<EventListViewModel>>
{
    /// <summary>
    /// Идентификатор агрегатора мероприятий
    /// </summary>
    [FromRoute]
    public Guid EventCreatorId { get; set; }

    /// <summary>
    /// Статус архивности
    /// </summary>
    [FromQuery]
    public bool? IsArchive { get; set; }
}