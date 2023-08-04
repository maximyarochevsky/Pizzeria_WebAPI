using AutoMapper;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Orders.Queries.ViewModels;

public class OrderItemVm : IMapWith<OrderItem>
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public ProductDetailsVm Product { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderItem, OrderItemVm>()
            .ForMember(orderItemVm => orderItemVm.Product,
            opt => opt.MapFrom(orderItem => orderItem.Product))
            .ForMember(orderItemVm => orderItemVm.Quantity,
            opt => opt.MapFrom(orderItem => orderItem.Quantity))
            .ForMember(orderItemVm => orderItemVm.Price,
            opt => opt.MapFrom(orderItem => orderItem.Price));
    }
}
