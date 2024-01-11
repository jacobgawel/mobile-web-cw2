using gevs_api.Data;
using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Repositories
{
    public class VoteHistoryRepository : IVoteHistoryRepository
    {
        private readonly GevsDbContext _gevsDbContext;

        public VoteHistoryRepository(GevsDbContext gevsDbContext)
        {
            _gevsDbContext = gevsDbContext;
        }

        public async Task<bool> AddVoteHistory(Guid id)
        {
            var vote = await _gevsDbContext.VoteHistory.FirstOrDefaultAsync(x => x.AccountId == id);
            if (vote == null)
            {
                VoteHistory voteHistory = new VoteHistory
                {
                    AccountId = id
                };

                await _gevsDbContext.VoteHistory.AddAsync(voteHistory);
                await _gevsDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> CheckVoteHistory(Guid id)
        {
            var vote = await _gevsDbContext.VoteHistory.AsNoTracking().FirstOrDefaultAsync(x => x.AccountId == id && x.HasVoted == true);

            if (vote == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteVoteHistory()
        {
            var votes = await _gevsDbContext.VoteHistory.ToListAsync();

            foreach (var vote in votes)
            {
                _gevsDbContext.VoteHistory.Remove(vote);
            }

            await _gevsDbContext.SaveChangesAsync();

            return true;
        }
    }
}
