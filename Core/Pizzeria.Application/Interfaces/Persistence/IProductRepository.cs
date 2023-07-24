using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface IProductRepository
{
    Task<Product> GetProductById(int id);
    Task<Product> GetProductsBySection(int id);
    Task<List<Product>> GetAllProducts();
}

