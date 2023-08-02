using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface ICartRepository
{
    bool AddCartItem(CartItem cartItem);
    bool IncrementCartItem(Guid Id);
    bool RemoveCartItem(Guid Id);
    bool DecrementCartItem(Guid Id);
    bool ClearCart();
    Task<Domain.Entities.Cart> GetCart();
}