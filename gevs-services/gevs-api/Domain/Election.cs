namespace gevs_api.Domain;

public class Election
{
    public Guid Id { get; set; }
    public bool Ongoing { get; set; } = false;
}