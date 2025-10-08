using GenericsRegistration.Demo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenericsRegistration.Demo;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories<TDbContext>(this IServiceCollection services,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
        where TDbContext : DbContext
    {
        var typesFromDbContext = typeof(TDbContext)
            .GetProperties()
            .Where(s => s.PropertyType.IsGenericType && s.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .SelectMany(s => s.PropertyType.GetGenericArguments())
            .ToArray();

        foreach (var t in typesFromDbContext)
        {
            var ifc = typeof(IRepository<>).MakeGenericType(t);
            var impl = typeof(Repository<,>).MakeGenericType(t, typeof(TDbContext));
            services.Add(new ServiceDescriptor(ifc, impl, lifetime));
        }

        return services;
    }
}