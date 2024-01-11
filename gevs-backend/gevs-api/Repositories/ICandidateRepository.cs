using gevs_api.Domain;

namespace gevs_api.Repositories
{
    public interface ICandidateRepository
    {
        Task<List<Candidate>> GetCandidates();
        Task<Candidate?> GetCandidateById(Guid id);
        Task<Guid> CreateCandidate(Candidate candidate);
        Task<bool> DeleteCandidates();
        Task<bool> AddVoteToCandidate(Guid id);
        Task<List<Candidate>?> GetCandidatesByConstituency(string constituencyName);
        Task<ConstituencyResult> GetConstituencyResults(List<Candidate> candidates, string constituencyName);
    }
}
