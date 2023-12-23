using Application.Abstractions.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.BaseUsers.Dtos;

public class RegistrationUserModel : UserModel, IMapWith<BaseUser>
{
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = null!;

    public new void Mapping(Profile profile)
    {
        profile.CreateMap<RegistrationUserModel, BaseUser>();
    }
}