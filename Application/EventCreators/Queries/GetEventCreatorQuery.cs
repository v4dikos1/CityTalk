using System.ComponentModel.DataAnnotations;
using Application.EventCreators.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.EventCreators.Queries;

public class GetEventCreatorQuery : IRequest<EventCreatorViewModel>
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [FromQuery]
    [Required]
    public Guid UserId { get; set; }
}