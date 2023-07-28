using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface ICartRepository
{
    Task<bool> AddCartItem(CartItem cartItem);
    bool IncrementCartItem();
    bool RemoveCartItem();
    bool DecrementCartItem();
    bool ClearCart();
    Task<List<CartItem>> GetCart();
}