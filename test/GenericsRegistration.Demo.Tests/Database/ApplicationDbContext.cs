using GenericsRegistration.Demo.Tests.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericsRegistration.Demo.Tests.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<EntityOne> Ones { get; set; }
    public DbSet<EntityTwo> Twos { get; set; }
    public DbSet<EntityThree> Threes { get; set; }
    public DbSet<EntityFour> Fours { get; set; }
}