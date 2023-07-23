using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.Application.Interfaces
{
    public interface IDbInitializer
    {
        Task<bool> RemoveAsync(CancellationToken token = default);
        Task InitializeAsync(bool RemoveBefore = false, CancellationToken token = default);
    }
}
