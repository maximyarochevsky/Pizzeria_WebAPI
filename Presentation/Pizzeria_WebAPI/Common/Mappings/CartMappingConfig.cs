using AutoMapper;
using Pizzeria.Application.Cart.Queries.ViewModels;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Contracts.Cart.Get;

namespace Pizzeria_WebAPI.Common.Mappings
{
    public class CartMappingConfig : IMapWith<CartVm>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartVm, GetCartResponse>()
                .ForMember(cartResponse => cartResponse.ItemsCount,
                    opt => opt.MapFrom(productVm => productVm.ItemsCount))
                .ForMember(cartResponse => cartResponse.TotalPrice,
                    opt => opt.MapFrom(productVm => productVm.TotalPrice))
                .ForMember(cartResponse => cartResponse.Items,
                    opt => opt.MapFrom(productVm => productVm.Items));
        }
    }
}
