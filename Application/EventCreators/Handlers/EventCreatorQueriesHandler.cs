using Application.EventCreators.Dtos;
using Application.EventCreators.Queries;
using AutoMapper;
using Domain;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.EventCreators.Handlers;

internal class EventCreatorQueriesHandler(ApplicationDbContext dbContext, IMapper mapper) : IRequestHandler<GetEventCreatorQuery, EventCreatorViewModel>
{
    public async Task<EventCreatorViewModel> Handle(GetEventCreatorQuery request, CancellationToken cancellationToken)
    {
        var existedEventCreator =
            await dbContext.EventCreators.SingleOrDefaultAsync(x => x.OwnerId == request.UserId, cancellationToken);
        if (existedEventCreator == null)
        {
            throw new ObjectNotFoundException(
                $"Агрегатор мероприятий для пользователя с идентификатором {request.UserId} не найден!");
        }
        return mapper.Map<EventCreatorViewModel>(existedEventCreator);
    }
}