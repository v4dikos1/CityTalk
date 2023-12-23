using Application.Abstractions;
using Application.Events.Dtos;
using Application.Events.Queries;
using AutoMapper;
using Domain;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Events.Handlers;

internal class EventQueriesHandler(ApplicationDbContext dbContext, IMapper mapper, ICurrentHttpContextAccessor contextAccessor)
    : IRequestHandler<GetEventsListQuery, IEnumerable<EventListViewModel>>
{
    public async Task<IEnumerable<EventListViewModel>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(contextAccessor.UserId);
        var eventCreator =
            await dbContext.EventCreators.SingleOrDefaultAsync(
                x => x.Id == request.EventCreatorId && x.OwnerId == userId, cancellationToken);
        if (eventCreator == null)
        {
            throw new ObjectNotFoundException(
                $"Агрегатор мероприятий с идентификатором {request.EventCreatorId} не найден!");
        }

        var events = dbContext.Events
            .Where(x => x.CreatorId == eventCreator.Id);

        if (request.IsArchive.HasValue)
        {
            events = events.Where(x => x.IsArchive == request.IsArchive.Value);
        }

        var eventsList = await events.ToListAsync(cancellationToken);
        return mapper.Map<IEnumerable<EventListViewModel>>(eventsList);
    }
}