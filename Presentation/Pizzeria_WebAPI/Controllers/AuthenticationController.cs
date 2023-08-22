using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Authentication.Commands;
using Pizzeria.Application.Authentication.Queries;
using Pizzeria.Contracts.Authentication;

namespace Pizzeria_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
        request.FirstName,
        request.LastName,
        request.Email,
        request.Password);

        var vm = await _mediator.Send(command);

        return vm.MatchFirst(
            reg => Ok(vm.Value),
            error => Problem(title: error.Description));
    }

    [HttpGet]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
       
        var vm = await _mediator.Send(query);

        return vm.MatchFirst(
                order => Ok(vm),
                error => Problem(title: error.Description)); ;
    }
}
