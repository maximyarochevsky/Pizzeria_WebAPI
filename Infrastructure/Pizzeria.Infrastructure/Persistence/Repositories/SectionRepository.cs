using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class SectionRepository : ISectionRepository
{
    public Task<List<Section>> GetAllSections()
    {
        throw new NotImplementedException();
    }
}



