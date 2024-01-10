using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories;

public class CandidateRepository(GevsDbContext context) : ICandidateRepository
{
    public async Task<List<Candidate>> GetCandidates()
    {
        var candidates = await context.Candidates.AsNoTracking().ToListAsync();
        return candidates;
    }

    public async Task<Candidate?> GetCandidateById(Guid id)
    {
        // gets the candidate by id
        var candidate = await context.Candidates.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
        return candidate;
    }

    public async Task<Guid> CreateCandidate(Candidate candidate)
    {
        // creates a new guid for the added candidate and returns it
        var generatedId = Guid.NewGuid();
        candidate.Id = generatedId;
        await context.Candidates.AddAsync(candidate);
        await context.SaveChangesAsync();

        return generatedId;
    }

    public async Task<bool> DeleteCandidates()
    {
        try
        {
            // returns the range of candidates that are in the database
            var candidates = context.Candidates;
            
            // will return true if they dont exist in the first place
            if (!candidates.Any()) return true;
            
            context.Candidates.RemoveRange(candidates);
            await context.SaveChangesAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            Console.WriteLine(ex.Message);
            return false;
        }
    }

}