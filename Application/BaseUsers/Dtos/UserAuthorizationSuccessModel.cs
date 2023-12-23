using Application.Abstractions.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.BaseUsers.Dtos;

public class UserAuthorizationSuccessModel
{
    /// <summary>
    /// Access token
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Refresh token
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;

    /// <summary>
    /// Refresh token expire time
    /// </summary>
    public DateTimeOffset RefreshTokenExpireIn { get; set; }
}