using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly GevsDbContext _context;

        public PartyRepository(GevsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Party>> GetParties()
        {
            return await _context.Parties.AsNoTracking().ToListAsync();
        }

        public async Task<Party?> GetPartyById(Guid id)
        {
            return await _context.Parties.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
