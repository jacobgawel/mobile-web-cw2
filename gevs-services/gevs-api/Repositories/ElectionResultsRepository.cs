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
            Party = "Independent",
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

            try
            {
                var candidate = candidates
                    .Aggregate((highest, next) => next.VoteCount > highest.VoteCount ? next : highest);

                var partyId = candidate.PartyId;
                var party = await context.Parties.AsNoTracking().FirstOrDefaultAsync(p => p.Id == partyId);

                electionResult.Seats.FirstOrDefault(s => party != null && s.Party == party.Name)!.Seat += 1;
            }
            catch (Exception)
            {
                // ignored
            }
        }
        
        var election = await context.Elections.AsNoTracking().ToListAsync();
        var electionStatus = election[0];
        
        var totalSeats = constituencies.Count;
        var majorityThreshold = totalSeats / 2;

        var winnerParty = electionResult.Seats
            .Aggregate((highest, next) => next.Seat > highest.Seat ? next : highest);

        var isHungParliament = winnerParty.Seat <= majorityThreshold;

        if (isHungParliament)
        {
            electionResult.Status = "Hung Parliament";
        }
        else
        {
            electionResult.Status = electionStatus.Ongoing ? "Pending" : "Completed";
            electionResult.Winner = winnerParty.Party;
        }
        
        var sortedResults = electionResult.Seats.OrderByDescending(er => er.Seat).ToList();

        electionResult.Seats = sortedResults;

        return electionResult;
    }
}