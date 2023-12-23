using Application.Events.Commands;
using FluentValidation;

namespace Application.Events.Validators;

internal class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(x => x.EventCreatorId)
            .NotEmpty()
            .WithMessage("Идентификатор агрегатора мероприятий обязателен к заполнению!");

        RuleFor(x => x.Body.Name)
            .NotEmpty()
            .WithMessage("Наименование мероприятия обязательно к заполнению!");

        RuleFor(x => x.Body.Description)
            .NotEmpty()
            .WithMessage("Описание мероприятия обязательно к заполнению!");

        RuleFor(x => x.Body.Address)
            .NotEmpty()
            .WithMessage("Адрес мероприятия обязателен к заполнению!");

        RuleFor(x => x.Body.StartDate)
            .NotEmpty()
            .WithMessage("Дата начала мероприятия обязательна к заполнению!");
    }
}