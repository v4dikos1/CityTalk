using Application.Abstractions;
using Application.Abstractions.DaData;
using Application.BaseModels;
using Application.Events.Commands;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Entities.Json;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Events.Handlers;

internal class EventCommandsHandler(ApplicationDbContext dbContext, IMapper mapper, ICurrentHttpContextAccessor currentHttpContextAccessor, IDaDataService daDataService)
    : IRequestHandler<CreateEventCommand, CreatedOrUpdatedEntityViewModel>, IRequestHandler<ArchiveEventCommand, EmptyViewModel>
{
    public async Task<CreatedOrUpdatedEntityViewModel> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(currentHttpContextAccessor.UserId);
        var eventCreator =
            await dbContext.EventCreators.SingleOrDefaultAsync(
                x => x.Id == request.EventCreatorId && x.OwnerId == userId, cancellationToken);
        if (eventCreator == null)
        {
            throw new ObjectNotFoundException(
                $"Агрегатор мероприятий с идентификатором {request.EventCreatorId} не найден!");
        }

        var eventToCreate = mapper.Map<Event>(request.Body);
        eventToCreate.Address = await GetAddress(request.Body.Address);
        eventToCreate.CreatorId = eventCreator.Id;
        var createdEvent = await dbContext.AddAsync(eventToCreate, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatedOrUpdatedEntityViewModel(createdEvent.Entity.Id);
    }

    public async Task<EmptyViewModel> Handle(ArchiveEventCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(currentHttpContextAccessor.UserId);
        var eventCreator =
            await dbContext.EventCreators.SingleOrDefaultAsync(
                x => x.Id == request.EventCreatorId && x.OwnerId == userId, cancellationToken);
        if (eventCreator == null)
        {
            throw new ObjectNotFoundException(
                $"Агрегатор мероприятий с идентификатором {request.EventCreatorId} не найден!");
        }

        var eventToArchive = await dbContext.Events.SingleOrDefaultAsync(x => x.Id == request.EventId, cancellationToken);
        if (eventToArchive == null)
        {
            throw new ObjectNotFoundException($"Мероприятие с идентификатором {request.EventId} не найдено!");
        }
        eventToArchive.IsArchive = true;
        await dbContext.SaveChangesAsync(cancellationToken);

        return new EmptyViewModel
        {
            Message = "Мероприятие успешно заархивировано!"
        };
    }

    private async Task<Address> GetAddress(string addressQuery)
    {
        var queryModel = new AddressQueryModel
        {
            Locations = null,
            FromBound = null,
            ToBound = null,
            Query = addressQuery,
            RestrictValue = true
        };
        var address = (await daDataService.GetListSuggestionAddressByQuery(queryModel)).FirstOrDefault();
        var result = mapper.Map<Address>(address);
        return result;
    }
}