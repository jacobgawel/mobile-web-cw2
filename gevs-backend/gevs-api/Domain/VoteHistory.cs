namespace gevs_api.Domain
{
    public class VoteHistory
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public bool HasVoted { get; set; } = true;
    }
}
