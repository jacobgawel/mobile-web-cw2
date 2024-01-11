using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories
{
    public class ConstituencyRepository : IConstituencyRepository
    {
        private readonly GevsDbContext _context;

        public ConstituencyRepository(GevsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Constituency>> GetConstituency()
        {
            return await _context.Constituencies.AsNoTracking().ToListAsync();
        }

        public async Task<Constituency?> GetConstituencyById(Guid id)
        {
            return await _context.Constituencies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
