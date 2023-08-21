using ErrorOr;
using System.Diagnostics;
using System.Net;

namespace Pizzeria.Application.Common.Exceptions;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Пользователь с данной почтой уже существует.");

        public static Error InvalidPassword => Error.Validation(
            code: "User.InvalidPassword",
            description: "Неверный пароль.");

        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "Пользователя с данной почтой не существует.");
    }
}
