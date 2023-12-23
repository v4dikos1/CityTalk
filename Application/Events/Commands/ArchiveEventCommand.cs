using Application.BaseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Events.Commands;

public class ArchiveEventCommand : IRequest<EmptyViewModel>
{
    /// <summary>
    /// Идентификатор агрегатора мероприятий
    /// </summary>
    [FromRoute]
    public Guid EventCreatorId { get; set; }

    /// <summary>
    /// Идентификатор мероприятия
    /// </summary>
    [FromRoute]
    public Guid EventId { get; set; }
}