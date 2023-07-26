using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class SectionRepository : GenericRepository<Section>, ISectionRepository
{
    public SectionRepository(PizzeriaDbContext dbContext):base(dbContext)
    { }

    public Task<List<Section>> GetAllSections()
    {
        return _dbContext.Sections.ToListAsync();
    }

    public Task<Section> GetSectionById(Guid id)
    {
        return _dbContext.Sections.FirstOrDefaultAsync(s => s.Id == id);
    }
}



