using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Contracts.Order.Get;

public record GetOrderResponse(
    string TotalPrice,
    string Description,
    string Address,
    string Phone,
    string Date,
    List<GetOrderItemResponse> OrderItems);

