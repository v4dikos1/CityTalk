using Application.Abstractions.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.EventCreators.Dtos;

public class EventCreatorViewModel : EventCreatorModel, IMapWith<EventCreator>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    public new void Mapping(Profile profile)
    {
        profile.CreateMap<EventCreator, EventCreatorViewModel>();

    }
}