using ExchangeRate.Tracker.Domain.ExchangeRates;

namespace ExchangeRate.Tracker.Domain.Base;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<IReadOnlyList<TEntity>> GetAllAsync();

    Task<TEntity> GetByAsync<TEntityId>(TEntityId id) where TEntityId : class, IEntityId;

    Task<TEntity> FindByAsync(IPagedFilter<TEntity> filter);

    Task<IReadOnlyList<TEntity>> FilterByAsync(IPagedFilter<TEntity> filter);
}
