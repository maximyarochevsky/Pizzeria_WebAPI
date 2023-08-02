using AutoMapper;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Contracts.Product.Get;

namespace Pizzeria_WebAPI.Common.Mappings
{
    public class ProductMappingConfig : IMapWith<ProductDetailsVm>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductDetailsVm, GetProductDetailsResponse>()
                .ForMember(productResponse => productResponse.Price,
                    opt => opt.MapFrom(productVm => productVm.Price))
                .ForMember(productResponse => productResponse.Name,
                opt => opt.MapFrom(productVm => productVm.Name))
                .ForMember(productResponse => productResponse.Description,
                opt => opt.MapFrom(productVm => productVm.Description))
                .ForMember(productResponse => productResponse.Section,
                opt => opt.MapFrom(productVm => productVm.Section));

            profile.CreateMap<ListProductsVm, GetProductsListResponse>()
                .ForMember(listResponse => listResponse.Products,
                    opt => opt.MapFrom(listVm => listVm.ListProducts));
        }
    }
}
