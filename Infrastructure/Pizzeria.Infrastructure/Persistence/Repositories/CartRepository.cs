using Microsoft.AspNetCore.Http;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class CartRepository :  ICartRepository
{

    private ISession session;
    public Task<bool> AddCartItem(CartItem cartItem)
    {
        if(session.TryGetValue())
        session.Set("Cart", cart);
    }

    public bool ClearCart()
    {
        throw new NotImplementedException();
    }

    public bool DecrementCartItem()
    {
        throw new NotImplementedException();
    }

    public Task<List<CartItem>> GetCart()
    {
        throw new NotImplementedException();
    }

    public bool IncrementCartItem()
    {
        throw new NotImplementedException();
    }

    public bool RemoveCartItem()
    {
        throw new NotImplementedException();
    }

}

