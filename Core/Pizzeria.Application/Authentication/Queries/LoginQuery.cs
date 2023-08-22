using ErrorOr;
using MediatR;
using Pizzeria.Application.Authentication.Common;

namespace Pizzeria.Application.Authentication.Queries;

public record LoginQuery(
     string Email,
     string Password) : IRequest<ErrorOr<AuthenticationResult>>;

