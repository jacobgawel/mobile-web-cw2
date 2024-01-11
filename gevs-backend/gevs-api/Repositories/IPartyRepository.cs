using gevs_api.Domain;

namespace gevs_api.Repositories
{
    public interface IPartyRepository
    {
        Task<List<Party>> GetParties();
        Task<Party?> GetPartyById(Guid id);
    }
}
