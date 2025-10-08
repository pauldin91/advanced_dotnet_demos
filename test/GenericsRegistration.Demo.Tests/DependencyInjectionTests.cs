using GenericsRegistration.Demo.Interfaces;
using GenericsRegistration.Demo.Tests.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace GenericsRegistration.Demo.Tests;

public class DependencyInjectionTests
{
    [Test]
    public void TestAddRepositories_ShouldRegister_AllIndividualRepositoriesFromDbContext()
    {
        var db = new ApplicationDbContext();
        var sp = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>()
            .AddRepositories<ApplicationDbContext>()
            .BuildServiceProvider();

        Type[] types = [typeof(EntityOne), typeof(EntityTwo), typeof(EntityThree), typeof(EntityFour)];
        foreach (var type in types)
        {
            var ifc = sp.GetRequiredService(typeof(IRepository<>).MakeGenericType(type));
            Assert.That(ifc, Is.Not.Null);
            Assert.That(ifc.GetType(),
                Is.EqualTo(typeof(Repository<,>).MakeGenericType(type, typeof(ApplicationDbContext))));
        }
    }
}