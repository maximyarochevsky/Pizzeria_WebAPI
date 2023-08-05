using Pizzeria.Application.Cart.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Contracts.Cart.Get;

public class GetCartResponse
{
    public List<CartItemVm>? Items { get; set; }
    public string ItemsCount => Items.Sum(item => item.Quantity).ToString();
    public string TotalPrice { get; set; }
}
