using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    User? GetUserByEmail(string email);
}
