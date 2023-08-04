using AutoMapper;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Queries.ViewModels;

public class CartItemVm : IMapWith<CartItem>
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CartItem, CartItemVm>()
              .ForMember(cartItemVm => cartItemVm.Price,
                  opt => opt.MapFrom(cartItem => cartItem.Price))
              .ForMember(cartItemVm => cartItemVm.Quantity,
                  opt => opt.MapFrom(cartItem => cartItem.Quantity))
              .ForMember(cartItemVm => cartItemVm.ProductId,
                  opt => opt.MapFrom(cartItem => cartItem.ProductId));
    }
}
