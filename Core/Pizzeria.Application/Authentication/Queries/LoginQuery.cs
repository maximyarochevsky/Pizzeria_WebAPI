using ErrorOr;
using MediatR;
using Pizzeria.Application.Authentication.Common;

namespace Pizzeria.Application.Authentication.Queries;

public class LoginQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
