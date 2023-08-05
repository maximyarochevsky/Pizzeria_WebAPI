using Pizzeria.Application.Orders.Queries.ViewModels;

namespace Pizzeria.Contracts.Order.Get;

public class GetAllOrdersResponse
{
    public List<GetOrderResponse> Orders;
}
