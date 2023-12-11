using System.Linq.Expressions;

namespace ExchangeRate.Tracker.Domain.Base;

public interface IFilter<TEntity> where TEntity : class, IEntity
{
    public Expression<Func<TEntity, bool>> Filter { get; }

    public string OrderBy { get; }

    public bool IsDesc { get; }

    public int Skip { get; }

    public int Limit { get; }

    public IFilter<TEntity> WithPaging(int skip, int limit);

    public IFilter<TEntity> WithOrderBy(string OrderBy, bool isDesc = false);
}
