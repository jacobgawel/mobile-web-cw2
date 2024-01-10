using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories;

public class ConstituencyRepository(GevsDbContext context) : IConstituencyRepository
{
    public async Task<List<Constituency>> GetConstituency()
    {
        return await context.Constituencies.AsNoTracking().ToListAsync();
    }

    public async Task<Constituency?> GetConstituencyById(Guid id)
    {
        return await context.Constituencies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }
}