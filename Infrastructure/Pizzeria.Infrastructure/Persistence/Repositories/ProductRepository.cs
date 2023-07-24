using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(PizzeriaDbContext dbContext):base(dbContext)
    {
    }

    public Task<List<Product>> GetAllProducts()
    {
        return _dbContext.Products
            .Include(p => p.Section)
            .ToListAsync();
    }

    public Task<Product> GetProductById(Guid id)
    {
        return _dbContext.Products.Include(p=>p.Section).FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<List<Product>> GetProductsBySection(Guid id)
    {
        return _dbContext.Products
            .Include(p => p.Section)
            .Where(p => p.Section.Id == id)
            .ToListAsync();
    }
}

