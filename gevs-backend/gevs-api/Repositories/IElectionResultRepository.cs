using gevs_api.Domain;

namespace gevs_api.Repositories
{
    public interface IElectionResultRepository
    {
        Task<ElectionResult> GetElectionResults();
    }
}
