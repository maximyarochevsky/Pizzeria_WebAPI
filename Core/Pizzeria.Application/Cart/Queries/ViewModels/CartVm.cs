using AutoMapper;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Queries.ViewModels;

public class CartVm : IMapWith<Domain.Entities.Cart>
{
    public List<CartItemVm>? Items { get; set; }
    public int ItemsCount => Items.Sum(item => item.Quantity);
    public decimal TotalPrice { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Cart, CartVm>()
               .ForMember(cartVm => cartVm.TotalPrice,
                   opt => opt.MapFrom(cart => cart.TotalPrice))
               .ForMember(cartVm => cartVm.ItemsCount,
                   opt => opt.MapFrom(cart => cart.ItemsCount))
               .ForMember(cartVm => cartVm.Items,
                   opt => opt.MapFrom(cart => cart.Items));
    }
}
