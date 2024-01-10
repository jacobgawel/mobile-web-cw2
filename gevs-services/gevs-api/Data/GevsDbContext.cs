using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Data;

public class GevsDbContext : DbContext
{
    public GevsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Constituency> Constituencies { get; set; }
    public DbSet<Party> Parties { get; set; }
}