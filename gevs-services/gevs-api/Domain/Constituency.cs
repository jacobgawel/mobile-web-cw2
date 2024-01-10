using System.ComponentModel.DataAnnotations;

namespace gevs_api.Domain;

public class Constituency
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}