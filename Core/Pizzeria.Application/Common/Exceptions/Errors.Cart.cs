using ErrorOr;

namespace Pizzeria.Application.Common.Exceptions;

public static partial class Errors
{
    public static class Cart
    {
        public static Error NullCart => Error.NotFound(
            code: "Cart.NullCart",
            description: "Корзина содержит null.");
    }
}
