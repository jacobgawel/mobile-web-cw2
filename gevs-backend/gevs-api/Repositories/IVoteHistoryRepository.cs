namespace gevs_api.Repositories
{
    public interface IVoteHistoryRepository
    {
        public Task<bool> AddVoteHistory(Guid id);
        public Task<bool> CheckVoteHistory(Guid id);
        public Task<bool> DeleteVoteHistory();
    }
}
