using Microsoft.AspNetCore.Http;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata;

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

    public bool IncrementCartItem(Guid Id)
    {
        ISession _session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        if(_session.GetString(Id.ToString()) != null)
        {
            var item = JsonSerializer.Deserialize<CartItem>(_session.GetString(Id.ToString()));
            decimal price = item.Price/item.Quantity;
            item.Quantity++;
            item.Price = item.Quantity * price; 
            _session.SetString(Id.ToString(), JsonSerializer.Serialize<CartItem>(item));

            return true;
        }

        return false;
    }

    public bool DecrementCartItem(Guid Id)
    {
        ISession _session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        if (_session.GetString(Id.ToString()) != null)
        {
            var item = JsonSerializer.Deserialize<CartItem>(_session.GetString(Id.ToString()));
            decimal price = item.Price / item.Quantity;
            item.Quantity--;

            if (item.Quantity == 0 || item.Quantity < 0)
            {
                _session.Remove(Id.ToString());
            }
            else
            {
                item.Price = item.Quantity * price;
                _session.SetString(Id.ToString(), JsonSerializer.Serialize<CartItem>(item));
            }

            return true;
        }

        return false;
    }

    public async Task<Cart> GetCart()
    {

        ISession _session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        List<CartItem> list = new List<CartItem>();
        decimal totalPrice = 0;
        foreach(var key in _session.Keys)
        {
            list.Add(JsonSerializer.Deserialize<CartItem>(_session.GetString(key)));
            totalPrice += JsonSerializer.Deserialize<CartItem>(_session.GetString(key)).Price;
        }

        Cart cart = new Cart()
        {
            Items = list,
            TotalPrice = totalPrice,
        };

        return cart;
    }

    public bool RemoveCartItem(Guid Id)
    {
        ISession _session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        _session.Remove(Id.ToString());

        if(_session.GetString(Id.ToString()) == null)
            return true;

        return false;
    }

    public bool ClearCart()
    {
        ISession _session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        _session.Clear();

        if(_session.Keys.Count() > 0 )
            return false;

        return true;
    }


}

