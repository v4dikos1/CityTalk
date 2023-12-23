using Application.Abstractions.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.EventCreators.Dtos;

public class EventCreatorModel : IMapWith<EventCreator>
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Доп. информация
    /// </summary>
    public string? Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<EventCreatorModel, EventCreator>();
        profile.CreateMap<EventCreator, EventCreatorModel>();
    }
}