using Application.BaseModels;
using Application.Events.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Events.Commands;

public class CreateEventCommand : IRequest<CreatedOrUpdatedEntityViewModel>
{
    /// <summary>
    /// Идентификатор агрегатора мероприятий
    /// </summary>
    [FromRoute]
    public Guid EventCreatorId { get; set; }

    /// <summary>
    /// Тело запроса
    /// </summary>
    [FromBody]
    public EventModel Body { get; set; } = null!;
}