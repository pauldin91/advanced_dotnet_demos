using System.Linq.Expressions;
using GenericsRegistration.Demo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GenericsRegistration.Demo;

public class Repository<TEntity, TDbContext>(TDbContext dbContext) : IRepository<TEntity>
    where TEntity : class
    where TDbContext : DbContext
{
    public Task<IQueryable<TEntity>> GetAllEntities(CancellationToken cancellationToken)
    {
        return Task.FromResult(dbContext.Set<TEntity>()
            .AsNoTracking()
            .AsQueryable());
    }

    public Task<IQueryable<TEntity>> FilterEntitiesBy(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(dbContext.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .AsQueryable())
            ;
    }
}