using gevs_api.Domain;

namespace gevs_api.Repositories;

public interface IElectionResultsRepository
{
    Task<ElectionResult> GetElectionResults();
}