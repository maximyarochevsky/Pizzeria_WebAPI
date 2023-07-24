using Pizzeria.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly PizzeriaDbContext _dbContext;

    public GenericRepository(PizzeriaDbContext dbContext)
    {
            _dbContext = dbContext;
    }

    public async Task<bool> Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        return true;
    }

    public bool Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return true;
    }

    public async Task<T?> FindById(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public bool Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return true;
    }
}

