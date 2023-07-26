using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface ISectionRepository
{
    Task<List<Section>> GetAllSections();
    Task<Section> GetSectionById(Guid id);
}

