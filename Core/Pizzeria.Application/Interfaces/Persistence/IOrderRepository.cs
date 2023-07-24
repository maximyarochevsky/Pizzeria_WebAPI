using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetAllOrders(int id);
    }
}
