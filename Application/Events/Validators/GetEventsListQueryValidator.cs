using Application.Events.Queries;
using FluentValidation;

namespace Application.Events.Validators;

internal class GetEventsListQueryValidator : AbstractValidator<GetEventsListQuery>
{
    public GetEventsListQueryValidator()
    {
        RuleFor(x => x.EventCreatorId)
            .NotEmpty()
            .WithMessage("Идентификатор агрегатора мероприятий обязателен к заполнению!");
    }
}