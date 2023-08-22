using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);


