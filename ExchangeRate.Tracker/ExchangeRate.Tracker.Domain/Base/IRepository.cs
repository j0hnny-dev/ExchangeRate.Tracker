using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExchangeRate.Tracker.Domain.Base;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<IReadOnlyList<TEntity>> GetAllAsync();

    Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> filter);

    Task<IReadOnlyList<TEntity>> FilterByAsync(IFilter<TEntity> filter);
}
