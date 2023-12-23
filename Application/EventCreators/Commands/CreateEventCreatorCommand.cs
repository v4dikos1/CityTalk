using Application.BaseModels;
using Application.EventCreators.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.EventCreators.Commands;

public class CreateEventCreatorCommand : IRequest<CreatedOrUpdatedEntityViewModel>
{
    /// <summary>
    /// Тело запроса
    /// </summary>
    [FromBody]
    public EventCreatorModel Body { get; set; } = null!;
}