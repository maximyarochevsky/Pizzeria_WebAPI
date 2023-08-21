using AutoMapper;
using ErrorOr;
using MediatR;
using Pizzeria.Application.Authentication.Common;
using Pizzeria.Application.Interfaces.Authentication;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Common.Exceptions;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(
        IUnitOfWork unitOfWork
        ,IMapper mapper
        , IJwtTokenGenerator jwtTokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (_unitOfWork.Users.GetUserByEmail(request.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
        };

        await _unitOfWork.Users.Add(user);
        await _unitOfWork.CompleteAsync();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        {
            User = user,
            Token = token,
        };
    }
}
