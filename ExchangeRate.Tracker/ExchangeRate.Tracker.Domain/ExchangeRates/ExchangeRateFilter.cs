using ExchangeRate.Tracker.Domain.Base;
using System.Linq.Expressions;

namespace ExchangeRate.Tracker.Domain.ExchangeRates;

public record ExchangeRateFilter : IFilter<ExchangeRateEntity>
{
    public Expression<Func<ExchangeRateEntity, bool>> Filter { get; private init; }

    public string OrderBy { get; private init; }

    public bool IsDesc { get; private init; }

    public int Skip { get; private init; }

    public int Limit { get; private init; }

    public static ExchangeRateFilter Create(string currency)
    {
        return new ExchangeRateFilter
        {
            Filter = x => x.Currency.Name == currency
        };
    }

    private ExchangeRateFilter()
    {

    }

    public IFilter<ExchangeRateEntity> WithPaging(int skip, int limit)
    {
        return this with
        {
            Skip = skip,
            Limit = limit
        };
    }

    public IFilter<ExchangeRateEntity> WithOrderBy(string OrderBy, bool isDesc = false)
    {
        return this with
        {
            OrderBy = OrderBy,
            IsDesc = isDesc
        };
    }
}