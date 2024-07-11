using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure.Context;
public class JourneyDbContext : DbContext
{
    public JourneyDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Trip> Trips { get; set; }

    public DbSet<Activity> Activities { get; set; }
}
