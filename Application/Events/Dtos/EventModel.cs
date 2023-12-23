using Application.Abstractions.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.Events.Dtos;

public class EventModel : IMapWith<Event>
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Дата начала
    /// </summary>
    public DateTimeOffset StartDate { get; set; }

    /// <summary>
    /// Дата окончания
    /// </summary>
    public DateTimeOffset? EndDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<EventModel, Event>()
            .ForMember(d => d.StartDate, opt => opt.MapFrom(src => src.StartDate.ToUniversalTime()))
            .ForMember(d => d.EndDate, opt => opt.MapFrom(src => src.EndDate.HasValue ? src.EndDate.Value.ToUniversalTime() : src.EndDate))
            .ForMember(d => d.Address, opt => opt.Ignore());
    }
}