using System.ComponentModel.DataAnnotations;

namespace gevs_api.Domain;

public class Candidate
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid PartyId { get; set; }
    public Guid ConstituencyId { get; set; }
    public int VoteCount { get; set; } = 0;
    
    public Constituency Constituency { get; set; }
    public Party Party { get; set; }
}