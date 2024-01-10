using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace gevs_api.Domain;

public class Constituency
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}