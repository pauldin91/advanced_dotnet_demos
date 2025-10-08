using GenericsRegistration.Demo.Tests.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericsRegistration.Demo.Tests;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EntityOne> Ones { get; set; }
    public DbSet<EntityTwo> Twos { get; set; }
    public DbSet<EntityThree> Threes { get; set; }
    public DbSet<EntityFour> Fours { get; set; }
}