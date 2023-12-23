using Application.BaseUsers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.BaseUsers.Commands;

public class AuthorizeBaseUserCommand : IRequest<UserAuthorizationSuccessModel>
{
    /// <summary>
    /// Тело запроса
    /// </summary>
    [FromBody]
    public LoginBaseUserModel Body { get; set; } = null!;
}