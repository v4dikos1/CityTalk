using Application.BaseModels;
using Application.BaseUsers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.BaseUsers.Commands;

/// <summary>
/// Создание пользователя
/// </summary>
public class CreateUserCommand() : IRequest<CreatedOrUpdatedEntityViewModel>
{
    /// <summary>
    /// Тело запроса
    /// </summary>
    [FromBody]
    public RegistrationUserModel Body { get; set; } = null!;
}