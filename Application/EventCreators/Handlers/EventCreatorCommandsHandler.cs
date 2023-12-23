using Application.Abstractions;
using Application.BaseModels;
using Application.EventCreators.Commands;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.EventCreators.Handlers;

internal class EventCreatorCommandsHandler(ApplicationDbContext dbContext, IMapper mapper, ICurrentHttpContextAccessor contextAccessor) 
    : IRequestHandler<CreateEventCreatorCommand, CreatedOrUpdatedEntityViewModel>
{
    public async Task<CreatedOrUpdatedEntityViewModel> Handle(CreateEventCreatorCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = Guid.Parse(contextAccessor.UserId);

        var eventCreatorExists =
            await dbContext.EventCreators.SingleOrDefaultAsync(x => x.OwnerId == currentUserId,
                cancellationToken);
        if (eventCreatorExists != null)
        {
            throw new ObjectExistsException(
                $"Пользователь не может быть владельцем нескольких агрегаторов мероприятий!");
        }

        var eventCreatorToCreate = mapper.Map<EventCreator>(request.Body);
        eventCreatorToCreate.OwnerId = currentUserId;
        var createdEventCreator = await dbContext.AddAsync(eventCreatorToCreate, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreatedOrUpdatedEntityViewModel(createdEventCreator.Entity.Id);
    }
}