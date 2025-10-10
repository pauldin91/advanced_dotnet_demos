using GenericsRegistration.Demo.Tests.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericsRegistration.Demo.Tests.Database;

public class ApiDbContext : DbContext
{
    public ApiDbContext()
    {
    }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Resource> Resources { get; set; }
    public DbSet<Owner> Owners { get; set; }
}