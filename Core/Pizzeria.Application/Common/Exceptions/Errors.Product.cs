using ErrorOr;

namespace Pizzeria.Application.Common.Exceptions;

public static partial class Errors
{
    public static class Product
    {
        public static Error InvalidId => Error.Validation(
            code: "Product.InvalidId",
            description: "Id товара неверен.");

        public static Error NotFound => Error.NotFound(
            code: "Product.NotFound",
            description: "Товар не найден.");
    }
}
