using ErrorOr;
using MediatR;
using Pizzeria.Application.Authentication.Common;

namespace Pizzeria.Application.Authentication.Commands;

public class RegisterCommand : IRequest<ErrorOr<AuthenticationResult>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
