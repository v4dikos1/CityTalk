using Application.Abstractions.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.BaseUsers.Dtos;

public class UserModel : IMapWith<BaseUser>
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; } = string.Empty;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<BaseUser, UserModel>();
        profile.CreateMap<UserModel, BaseUser>();
    }
}