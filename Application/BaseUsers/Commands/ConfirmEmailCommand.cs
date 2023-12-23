using Application.BaseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.BaseUsers.Commands;

public class ConfirmEmailCommand : IRequest<EmptyViewModel>
{
    /// <summary>
    /// Код подтверждения
    /// </summary>
    [FromQuery]
    public string Code { get; set; } = string.Empty;
}