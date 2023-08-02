using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Application.Common.Exceptions;
public static partial class Errors
{
    public static class Section
    {
        public static Error InvalidId => Error.Validation(
            code: "Product.InvalidId",
            description: "Id секции неверен.");

        public static Error NotFound => Error.NotFound(
            code: "Product.NotFound",
            description: "Секция не найдена.");
    }
}
