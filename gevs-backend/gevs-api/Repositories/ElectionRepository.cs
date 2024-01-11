using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories
{
    public class ElectionRepository : IElectionRepository
    {
        private readonly GevsDbContext _context;

        public ElectionRepository(GevsDbContext context)
        {
            _context = context;
        }

        public async Task<Election> GetElection()
        {
            var status = await _context.Elections.AsNoTracking().ToListAsync();
            return status[0];
        }

        public async Task<bool> UpdateElectionStatus(bool status)
        {
            var election = await _context.Elections.ToListAsync();
            var electionStatus = election[0];
            electionStatus.Ongoing = status;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
