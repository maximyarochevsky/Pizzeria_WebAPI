using Pizzeria.Domain.Entities.Base;
using Pizzeria.Domain.Entities;
using AutoMapper;
using Pizzeria.Application.Common.Mappings;

namespace Pizzeria.Application.Orders.Queries.ViewModels;

public class OrderVm : IMapWith<Order>
{
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime Date { get; set; }
    public List<OrderItemVm> OrderItems { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderVm>()
            .ForMember(orderVm => orderVm.TotalPrice,
            opt => opt.MapFrom(order => order.TotalPrice))
            .ForMember(orderVm => orderVm.Description,
            opt => opt.MapFrom(order => order.Description))
            .ForMember(orderVm => orderVm.Address,
            opt => opt.MapFrom(order => order.Address))
            .ForMember(orderVm => orderVm.Phone,
            opt => opt.MapFrom(order => order.Phone))
            .ForMember(orderVm => orderVm.Date,
            opt => opt.MapFrom(order => order.Date))
            .ForMember(orderVm => orderVm.OrderItems,
            opt => opt.MapFrom(order => order.OrderItems));
    }
}
