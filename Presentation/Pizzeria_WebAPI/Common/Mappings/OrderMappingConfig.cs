using AutoMapper;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Contracts.Order.Get;

namespace Pizzeria_WebAPI.Common.Mappings;

public class OrderMappingConfig : IMapWith<OrderVm>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderVm, GetOrderResponse>()
            .ForMember(orderResponse => orderResponse.Address,
                opt => opt.MapFrom(order => order.Address))
            .ForMember(orderResponse => orderResponse.TotalPrice,
                opt => opt.MapFrom(order => order.TotalPrice))
            .ForMember(orderResponse => orderResponse.Date,
                opt => opt.MapFrom(order => order.Date))
            .ForMember(orderResponse => orderResponse.Description,
                opt => opt.MapFrom(order => order.Description))
            .ForMember(orderResponse => orderResponse.OrderItems,
                opt => opt.MapFrom(order => order.OrderItems))
            .ForMember(orderResponse => orderResponse.Phone,
                opt => opt.MapFrom(order => order.Phone));

        profile.CreateMap<ListOrdersVm, GetAllOrdersResponse>()
            .ForMember(listResponse => listResponse.Orders,
                opt => opt.MapFrom(listVm => listVm.Orders));

        profile.CreateMap<OrderItemVm, GetOrderItemResponse>()
            .ForMember(orderItemResponse => orderItemResponse.Product,
            opt => opt.MapFrom(orderItemVm => orderItemVm.Product))
            .ForMember(orderItemResponse => orderItemResponse.Quantity,
            opt => opt.MapFrom(orderItemVm => orderItemVm.Quantity))
            .ForMember(orderItemResponse => orderItemResponse.Price,
            opt => opt.MapFrom(orderItemVm => orderItemVm.Price));
    }
}
