using FluentValidation;

namespace Pizzeria.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(order => order.Address).MinimumLength(10);
        RuleFor(order => order.Description).MaximumLength(400);
        RuleFor(order => order.Phone).MaximumLength(13)
        .MinimumLength(10)
        .Matches(@"^\+?[0-9]+$").WithMessage("Номер телефона должен содержать только цифры и символ '+'."); 
    }
}
