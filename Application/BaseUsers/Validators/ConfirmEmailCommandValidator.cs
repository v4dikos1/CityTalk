using Application.BaseUsers.Commands;
using FluentValidation;

namespace Application.BaseUsers.Validators;

internal class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
{
    public ConfirmEmailCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Код подтверждения обязателен к заполнению!");
    }
}