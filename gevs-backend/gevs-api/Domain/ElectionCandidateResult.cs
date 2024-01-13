namespace gevs_api.Domain;

public class ElectionCandidateResult
{
    public string Constituency { get; set; }
    public List<ElectionCandidateBody> Candidates { get; set; }
}