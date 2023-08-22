using ErrorOr;
using MediatR;
using Pizzeria.Application.Authentication.Common;

namespace Pizzeria.Application.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

