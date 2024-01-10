using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories;

public class PartyRepository(GevsDbContext context) : IPartyRepository
{
    public async Task<List<Party>> GetParties()
    {
        return  await context.Parties.AsNoTracking().ToListAsync();
    }

    public async Task<Party?> GetPartyById(Guid id)
    {
        return await context.Parties.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }
}