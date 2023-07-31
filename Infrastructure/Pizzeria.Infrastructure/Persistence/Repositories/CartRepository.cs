using Microsoft.AspNetCore.Http;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class CartRepository :  ICartRepository
{
    private readonly IServiceProvider _services;
    public CartRepository(IServiceProvider services)
    {
        _services = services;
    }
    
    public bool AddCartItem(CartItem cartItem)
    {
        ISession _session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        if(_session.GetString(cartItem.ProductId.ToString()) != cartItem.ProductId.ToString())
        {
            _session.SetString(cartItem.ProductId.ToString(), JsonSerializer.Serialize<CartItem>(cartItem));
            return true;
        }
        return false;
    }

    public bool ClearCart()
    {
        throw new NotImplementedException();
    }

    public bool DecrementCartItem()
    {
        throw new NotImplementedException();
    }

    public async Task<List<CartItem>> GetCart()
    {
        ISession _session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        List<CartItem> list = new List<CartItem>();
        foreach(var key in _session.Keys)
        {
            list.Add(JsonSerializer.Deserialize<CartItem>(_session.GetString(key)));
        }

        return list;
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

