using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories;

public class ElectionRepository(GevsDbContext context) : IElectionRepository
{
    public async Task<Election> GetElection()
    {
        var status = await context.Elections.AsNoTracking().ToListAsync();
        return status[0];
    }

    public async Task<bool> UpdateElectionStatus(bool status)
    {
        var election = await context.Elections.ToListAsync();
        var electionStatus = election[0];
        electionStatus.Ongoing = status;
        
        await context.SaveChangesAsync();
        
        return true;
    }
}