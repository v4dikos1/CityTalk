using Application.Abstractions.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.Events.Dtos;

public class EventListViewModel : EventModel, IMapWith<Event>
{
    /// <summary>
    /// Идентификатор мероприятия
    /// </summary>
    public Guid Id { get; set; }

    public new void Mapping(Profile profile)
    {
        profile.CreateMap<Event, EventListViewModel>()
            .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address.AddressFullName));
    }
}