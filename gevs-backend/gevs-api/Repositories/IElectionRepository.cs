using gevs_api.Domain;

namespace gevs_api.Repositories
{
    public interface IElectionRepository
    {
        Task<Election> GetElection();
        Task<bool> UpdateElectionStatus(bool status);
    }
}
