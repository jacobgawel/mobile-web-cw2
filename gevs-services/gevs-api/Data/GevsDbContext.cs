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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Party>().HasData(
            new Party
            {
               Id = Guid.NewGuid(),
               Name = "Red Party"
            },
            new Party
            {
                Id = Guid.NewGuid(),
                Name = "Blue Party"
            },
            new Party
            {
                Id = Guid.NewGuid(),
                Name = "Yellow Party"
            },
            new Party
            {
                Id = Guid.NewGuid(),
                Name = "Independent"
            }
        );
    }
}