using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Contracts.Order.Get;

public class GetOrderResponse
{
    public string TotalPrice { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Date { get; set; }
    public List<GetOrderItemResponse> OrderItems { get; set; }
}
    

