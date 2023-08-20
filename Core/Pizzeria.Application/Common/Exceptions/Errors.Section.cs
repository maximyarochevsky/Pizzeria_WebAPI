using ErrorOr;
using System;


namespace Pizzeria.Application.Common.Exceptions;
public static partial class Errors
{
    public static class Section
    {
        public static Error InvalidId => Error.Validation(
            code: "Section.InvalidId",
            description: "Id секции неверен.");

        public static Error NotFound => Error.NotFound(
            code: "Section.NotFound",
            description: "Секция не найдена.");
    }
}
