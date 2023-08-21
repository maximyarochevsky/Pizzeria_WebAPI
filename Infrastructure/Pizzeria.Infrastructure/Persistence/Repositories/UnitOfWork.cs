using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PizzeriaDbContext _dbContext;
        public IOrderItemRepository OrderItems { get; }
        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }
        public ISectionRepository Sections { get; }
        public ICartRepository Cart { get; }

        public IUserRepository Users { get; }

        public UnitOfWork(PizzeriaDbContext dbContext
        ,IOrderRepository orders
        ,IOrderItemRepository orderItems
        ,IProductRepository products
        ,ICartRepository cart
        ,ISectionRepository sections
        ,IUserRepository users)
        {
                _dbContext = dbContext;
                Orders = orders; 
                OrderItems = orderItems;
                Products = products;
                Cart = cart;
                Sections = sections;
                Users = users;
        }

        public async Task<bool> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
