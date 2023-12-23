using Application.Events.Commands;
using FluentValidation;

namespace Application.Events.Validators;

internal class ArchiveEventCommandValidator : AbstractValidator<ArchiveEventCommand>
{
    public ArchiveEventCommandValidator()
    {
        RuleFor(x => x.EventCreatorId)
            .NotEmpty()
            .WithMessage("Идентификатор агрегатора мероприятий обязателен к заполнению!");

        RuleFor(x => x.EventId)
            .NotEmpty()
            .WithMessage("Идентификатор мероприятия обязателен к заполнению!");
    }
}