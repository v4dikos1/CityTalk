using Application.BaseUsers.Commands;
using FluentValidation;

namespace Application.BaseUsers.Validators;

internal class AuthorizeBaseUserCommandValidator : AbstractValidator<AuthorizeBaseUserCommand>
{
    public AuthorizeBaseUserCommandValidator()
    {
        RuleFor(x => x.Body.Email)
            .NotEmpty()
            .WithMessage("Почта обязательна к заполнению!")
            .EmailAddress()
            .WithMessage("Почта имеет некорректный формат!");

        RuleFor(x => x.Body.Password)
            .NotEmpty()
            .WithMessage("Пароль обязателен к заполнению!");
    }
}