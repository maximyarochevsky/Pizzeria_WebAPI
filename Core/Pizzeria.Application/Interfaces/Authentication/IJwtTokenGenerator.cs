using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
