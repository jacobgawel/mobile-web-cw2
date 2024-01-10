using gevs_api.Domain;

namespace gevs_api.Repositories;

public interface IConstituencyRepository
{
    Task<List<Constituency>> GetConstituency();
    Task<Constituency?> GetConstituencyById(Guid id);
}