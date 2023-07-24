using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        IOrderItemRepository OrderItems { get;}
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ISectionRepository Sections { get; }

        Task<bool> CompleteAsync();
    }
}
