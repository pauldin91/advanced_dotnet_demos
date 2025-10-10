using GenericsRegistration.Demo.Interfaces;
using GenericsRegistration.Demo.Tests.Database;
using GenericsRegistration.Demo.Tests.Database.Entities;
using GenericsRegistration.Demo.Tests.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace GenericsRegistration.Demo.Tests;

public class DependencyInjectionTests
{
    private readonly List<Type> _apiDbContextSets = [typeof(Resource), typeof(Owner)];

    private readonly List<Type> _applicationDbContextSets =
        [typeof(EntityOne), typeof(EntityTwo), typeof(EntityThree), typeof(EntityFour)];

    [Test]
    public void TestAddRepositories_ShouldRegister_AllIndividualRepositoriesFromDbContext()
    {
        var sp = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>()
            .AddRepositories<ApplicationDbContext>()
            .BuildServiceProvider();

        foreach (var type in _applicationDbContextSets)
        {
            var ifc = sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(type));
            Assert.That(ifc, Is.Not.Null);
            Assert.That(ifc.GetType(),
                Is.EqualTo(typeof(Repository<,>).MakeGenericType(type, typeof(ApplicationDbContext))));
        }
    }

    [Test]
    public void TestRegistrationOfAllRepositoriesForMultipleDbContexts()
    {
        var serviceCollection = new ServiceCollection();

        var sp = serviceCollection
            .AddDbContext<ApplicationDbContext>()
            .AddDbContext<ApiDbContext>()
            .AddRepositories<ApplicationDbContext>()
            .AddRepositories<ApiDbContext>()
            .BuildServiceProvider();

        foreach (var type in _applicationDbContextSets)
        {
            var repo = sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(type));
            Assert.That(repo, Is.Not.Null);
            Assert.That(repo.GetType(),
                Is.EqualTo(typeof(Repository<,>).MakeGenericType(type, typeof(ApplicationDbContext))));
        }

        foreach (var type in _apiDbContextSets)
        {
            var repo = sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(type));
            Assert.That(repo, Is.Not.Null);
            Assert.That(repo.GetType(),
                Is.EqualTo(typeof(Repository<,>).MakeGenericType(type, typeof(ApiDbContext))));
        }
    }
}