using Application.EventCreators.Queries;
using FluentValidation;

namespace Application.EventCreators.Validators;

internal class GetEventCreatorQueryValidator : AbstractValidator<GetEventCreatorQuery>
{
    public GetEventCreatorQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("Идентификатор пользователя обязателен к заполнению!");
    }
}