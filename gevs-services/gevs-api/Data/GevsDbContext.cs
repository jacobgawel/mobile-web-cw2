using Microsoft.EntityFrameworkCore;

namespace gevs_api.Data;

public class GevsDbContext : DbContext
{
    public GevsDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<>
}