using Pizzeria.Application.Orders.Queries.ViewModels;

namespace Pizzeria.Contracts.Order.Get;

public record GetAllOrdersResponse(List<GetOrderResponse> Orders);

