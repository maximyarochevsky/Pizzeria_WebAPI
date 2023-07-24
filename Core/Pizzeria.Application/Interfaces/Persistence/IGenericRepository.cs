using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Application.Interfaces.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> FindById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
    }
}
