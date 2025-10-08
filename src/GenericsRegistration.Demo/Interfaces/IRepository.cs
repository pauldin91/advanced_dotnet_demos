using System.Linq.Expressions;

namespace GenericsRegistration.Demo.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    Task<IQueryable<TEntity>> GetAllEntities(CancellationToken cancellationToken);

    Task<IQueryable<TEntity>> FilterEntitiesBy(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken);
}