using Application.EventCreators.Commands;
using FluentValidation;

namespace Application.EventCreators.Validators;

internal class CreateEventCreatorCommandValidator : AbstractValidator<CreateEventCreatorCommand>
{
    public CreateEventCreatorCommandValidator()
    {
        RuleFor(x => x.Body.Name)
            .NotEmpty()
            .WithMessage("Наименование обязательно к заполнению!");
    }
}