namespace gevs_api.Domain;

public class ElectionResult
{
    public string Status { get; set; }
    public string Winner { get; set; }
    public List<Seats> Seats { get; set; } = new List<Seats>();
}