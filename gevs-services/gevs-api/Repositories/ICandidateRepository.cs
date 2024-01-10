using gevs_api.Domain;

namespace gevs_api.Repositories;

public interface ICandidateRepository
{
    Task<List<Candidate>> GetCandidates();
    Task<Candidate?> GetCandidateById(Guid id);
    Task<Guid> CreateCandidate(Candidate candidate);
    Task<bool> DeleteCandidates();
}