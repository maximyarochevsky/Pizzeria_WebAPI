using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(PizzeriaDbContext dbContext) : base(dbContext)
    {
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(x => x.Email == email);
    }
}
