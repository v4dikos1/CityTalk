using Application.BaseUsers.Commands;
using FluentValidation;

namespace Application.BaseUsers.Validators;

internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Body.Name)
            .NotEmpty()
            .WithMessage("Имя обязательно к заполнению!");

        RuleFor(x => x.Body.Surname)
            .NotEmpty()
            .WithMessage("Фамилия обязательна к заполнению!");

        RuleFor(x => x.Body.Email)
            .NotEmpty()
            .WithMessage("Почта обязательна к заполнению!")
            .EmailAddress()
            .WithMessage("Почта имеет недопустимый формат!");

        RuleFor(x => x.Body.Password)
            .NotEmpty()
            .WithMessage("Пароль обязателен к заполнению!");
    }
}