using FluentValidation;

namespace Pizzeria.Application.Authentication.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(model => model.FirstName)
         .NotEmpty().WithMessage("Имя не должно быть пустым.")
         .MaximumLength(50).WithMessage("Имя не должно превышать 50 символов.");

        RuleFor(model => model.LastName)
            .NotEmpty().WithMessage("Фамилия не должна быть пустой.")
            .MaximumLength(50).WithMessage("Фамилия не должна превышать 50 символов.");

        RuleFor(model => model.Email)
            .NotEmpty().WithMessage("Email не должен быть пустым.")
            .EmailAddress().WithMessage("Некорректный формат Email.");

        RuleFor(model => model.Password)
            .NotEmpty().WithMessage("Пароль не должен быть пустым.")
            .MinimumLength(6).WithMessage("Пароль должен содержать не менее 6 символов.");
    }
}
