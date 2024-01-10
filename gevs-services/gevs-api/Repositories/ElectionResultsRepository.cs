using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories;

public class ElectionResultsRepository(GevsDbContext context) : IElectionResultsRepository
{
    public async Task<ElectionResult> GetElectionResults()
    {
        ElectionResult electionResult = new ElectionResult();
        
        Seats yellowParty = new Seats() {
            Party = "Yellow Party",
            Seat = 0
        };

        Seats redParty = new Seats()
        {
            Party = "Red Party",
            Seat = 0
        };

        Seats blueParty = new Seats()
        {
            Party = "Blue Party",
            Seat = 0
        };

        Seats independent = new Seats()
        {
            Party = "Indepenent",
            Seat = 0
        };
        
        electionResult.Seats.Add(yellowParty);
        electionResult.Seats.Add(redParty);
        electionResult.Seats.Add(blueParty);
        electionResult.Seats.Add(independent);
        
        var constituencies = await context.Constituencies.AsNoTracking().ToListAsync();
        
        foreach (var constituency in constituencies)
        {
            var constituencyId = constituency.Id;
            var candidates = await context.Candidates.AsNoTracking()
                .Where(c => c.ConstituencyId == constituencyId).ToListAsync();
            
            var candidate = candidates
                .Aggregate((highest, next) => next.VoteCount > highest.VoteCount ? next : highest);
            
            var partyId = candidate.PartyId;
            var party = await context.Parties.FirstOrDefaultAsync(p => p.Id == partyId);
            
            electionResult.Seats.FirstOrDefault(s => party != null && s.Party == party.Name)!.Seat += 1;
        }
        
        var winnerParty = electionResult.Seats
            .Aggregate((next, party) => next.Seat > party.Seat ? next : party);

        electionResult.Status = "Completed";
        electionResult.Winner = winnerParty.Party;

        return electionResult;
    }
}