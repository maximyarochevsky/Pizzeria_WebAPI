using AutoMapper;
using ErrorOr;
using MediatR;
using Pizzeria.Application.Authentication.Common;
using Pizzeria.Application.Interfaces.Authentication;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Common.Exceptions;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Authentication.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(
        IUnitOfWork unitOfWork
        , IMapper mapper
        , IJwtTokenGenerator jwtTokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (_unitOfWork.Users.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.User.NotFound;
        }

        if (request.Password != user.Password)
        {
            return Errors.User.InvalidPassword;
        }

        var token = _jwtTokenGenerator.GenerateToken(
            user);

        return new AuthenticationResult
        {
            User = user,
            Token = token,
        };
    }
}
