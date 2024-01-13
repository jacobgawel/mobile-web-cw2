namespace gevs_api.Domain;

public class ElectionCandidateBody
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    public string Party { get; set; }
    public int Votes { get; set; }
}