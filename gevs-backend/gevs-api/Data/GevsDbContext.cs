using gevs_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace gevs_api.Data
{
    public class GevsDbContext : DbContext
    {
        public GevsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Constituency> Constituencies { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<VoteHistory> VoteHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var redId = Guid.NewGuid();
            var blueId = Guid.NewGuid();
            var yellowId = Guid.NewGuid();
            var independentId = Guid.NewGuid();

            var shangriId = Guid.NewGuid();
            var northernId = Guid.NewGuid();
            var westernId = Guid.NewGuid();
            var nabooId = Guid.NewGuid();
            var newId = Guid.NewGuid();

            modelBuilder.Entity<Party>().HasData(
                new Party
                {
                    Id = redId,
                    Name = "Red Party"
                },
                new Party
                {
                    Id = blueId,
                    Name = "Blue Party"
                },
                new Party
                {
                    Id = yellowId,
                    Name = "Yellow Party"
                },
                new Party
                {
                    Id = independentId,
                    Name = "Independent"
                }
            );

            modelBuilder.Entity<Election>().HasData(
                new Election
                {
                    Id = Guid.NewGuid(),
                    Ongoing = false
                }
            );

            modelBuilder.Entity<Constituency>().HasData(
                new Constituency
                {
                    Id = shangriId,
                    Name = "Shangri-la-Town"
                },
                new Constituency
                {
                    Id = northernId,
                    Name = "Northern-Kunlun-Mountain"
                },
                new Constituency
                {
                    Id = westernId,
                    Name = "Western-Shangri-la"
                },
                new Constituency
                {
                    Id = nabooId,
                    Name = "Naboo-Vallery"
                },
                new Constituency
                {
                    Id = newId,
                    Name = "New-Felucia"
                }
            );
            
            // 1 seat for RED
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 1",
                    PartyId = redId,
                    ConstituencyId = northernId,
                    VoteCount = 4
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 2",
                    PartyId = blueId,
                    ConstituencyId = northernId,
                    VoteCount = 2
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 3",
                    PartyId = yellowId,
                    ConstituencyId = northernId,
                    VoteCount = 1
                }
            );
            
            // 1 seat for RED
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 1",
                    PartyId = redId,
                    ConstituencyId = shangriId,
                    VoteCount = 4
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 2",
                    PartyId = blueId,
                    ConstituencyId = shangriId,
                    VoteCount = 2
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 3",
                    PartyId = yellowId,
                    ConstituencyId = shangriId,
                    VoteCount = 1
                }
            );
            
            // 1 seat for RED
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 1",
                    PartyId = independentId,
                    ConstituencyId = westernId,
                    VoteCount = 0
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 2",
                    PartyId = blueId,
                    ConstituencyId = westernId,
                    VoteCount = 4
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 3",
                    PartyId = redId,
                    ConstituencyId = westernId,
                    VoteCount = 2
                }
            );

            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 1",
                    PartyId = redId,
                    ConstituencyId = nabooId,
                    VoteCount = 3
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 2",
                    PartyId = blueId,
                    ConstituencyId = nabooId,
                    VoteCount = 0
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 3",
                    PartyId = yellowId,
                    ConstituencyId = nabooId,
                    VoteCount = 1
                }
            );
            
            // 1 seat for yellow
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 1",
                    PartyId = redId,
                    ConstituencyId = newId,
                    VoteCount = 2
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 2",
                    PartyId = blueId,
                    ConstituencyId = newId,
                    VoteCount = 0
                },
                new Candidate
                {
                    Id = Guid.NewGuid(),
                    Name = "candidate 3",
                    PartyId = yellowId,
                    ConstituencyId = newId,
                    VoteCount = 6
                }
            );
        }
    }
}
