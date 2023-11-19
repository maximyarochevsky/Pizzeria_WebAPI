
using AutoMapper;
using Pizzeria.Application.Cart.Queries.ViewModels;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Application.Sections.Queries.ViewModels;
using Pizzeria.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pizzeria_WebAPI.Tests;

internal class Mappings : Profile
{
    public Mappings()
    {
      CreateMap<Product, ProductDetailsVm>()
        .ForMember(productVm => productVm.Price,
            opt => opt.MapFrom(product => product.Price))
        .ForMember(productVm => productVm.Name,
        opt => opt.MapFrom(product => product.Name))
        .ForMember(productVm => productVm.Description,
        opt => opt.MapFrom(product => product.Description))
        .ForMember(productVm => productVm.Section,
        opt => opt.MapFrom(product => product.Section.Name));

        CreateMap<Order, OrderVm>()
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

        CreateMap<OrderItem, OrderItemVm>()
            .ForMember(orderItemVm => orderItemVm.Product,
            opt => opt.MapFrom(orderItem => orderItem.Product))
            .ForMember(orderItemVm => orderItemVm.Quantity,
            opt => opt.MapFrom(orderItem => orderItem.Quantity))
            .ForMember(orderItemVm => orderItemVm.Price,
            opt => opt.MapFrom(orderItem => orderItem.Price));

        CreateMap<Section, SectionVm>()
            .ForMember(sectionVm => sectionVm.Name,
            opt => opt.MapFrom(section => section.Name));

        CreateMap<Pizzeria.Domain.Entities.Cart, CartVm>()
            .ForMember(cartVm => cartVm.TotalPrice,
                opt => opt.MapFrom(cart => cart.TotalPrice))
            .ForMember(cartVm => cartVm.ItemsCount,
                opt => opt.MapFrom(cart => cart.ItemsCount))
            .ForMember(cartVm => cartVm.Items,
                opt => opt.MapFrom(cart => cart.Items));

        CreateMap<CartItem, CartItemVm>()
              .ForMember(cartItemVm => cartItemVm.Price,
                  opt => opt.MapFrom(cartItem => cartItem.Price))
              .ForMember(cartItemVm => cartItemVm.Quantity,
                  opt => opt.MapFrom(cartItem => cartItem.Quantity))
              .ForMember(cartItemVm => cartItemVm.ProductId,
                  opt => opt.MapFrom(cartItem => cartItem.ProductId));

        CreateMap<Pizzeria.Domain.Entities.Cart, CartVm>()
               .ForMember(cartVm => cartVm.TotalPrice,
                   opt => opt.MapFrom(cart => cart.TotalPrice))
               .ForMember(cartVm => cartVm.ItemsCount,
                   opt => opt.MapFrom(cart => cart.ItemsCount))
               .ForMember(cartVm => cartVm.Items,
                   opt => opt.MapFrom(cart => cart.Items));
    }
}

  
