namespace ExchangeRate.Tracker.Domain.Base;

public interface IPagedFilter<TEntity> where TEntity : class, IEntity
{
    public string OrderBy { get; }

    public bool IsDesc { get; }

    public int Skip { get; }

    public int Limit { get; }

    public IPagedFilter<TEntity> WithPaging(int skip, int limit);

    public IPagedFilter<TEntity> WithOrderBy(string OrderBy, bool isDesc = false);
}
