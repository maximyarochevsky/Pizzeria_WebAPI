using ErrorOr;

namespace Pizzeria.Application.Common.Exceptions;

public static partial class Errors
{
    public static class Order
    {
        public static Error InvalidId => Error.Validation(
            code: "Order.InvalidId",
            description: "Id заказа неверен.");

        public static Error NotFound => Error.NotFound(
            code: "Order.NotFound",
            description: "Заказ не найден.");

        public static Error NullItems => Error.NotFound(
            code: "Order.NotFound",
            description: "Не добавлено ни одного товара.");
    }
}
