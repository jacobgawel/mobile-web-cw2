namespace gevs_api.Domain
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PartyId { get; set; }
        public Guid ConstituencyId { get; set; }
        public int VoteCount { get; set; }
        private Constituency Constituency { get; set; }
        private Party Party { get; set; }
    }
}
