using ErrorOr;

namespace Pizzeria.Application.Common.Exceptions;

public static partial class Errors
{
    public static class Order
    {
        public static Error InvalidId => Error.Validation(
            code: "Product.InvalidId",
            description: "Id заказа неверен.");

        public static Error NotFound => Error.NotFound(
            code: "Product.NotFound",
            description: "Заказ не найден.");
    }
}
