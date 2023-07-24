using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface IProductRepository
{
    Task<Product> GetProductById(Guid id);
    Task<List<Product>> GetProductsBySection(Guid id);
    Task<List<Product>> GetAllProducts();
}

