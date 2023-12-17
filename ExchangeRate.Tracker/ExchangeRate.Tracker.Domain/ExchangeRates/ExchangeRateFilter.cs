using ExchangeRate.Tracker.Domain.Base;

namespace ExchangeRate.Tracker.Domain.ExchangeRates;

public record ExchangeRateFilter : IPagedFilter<ExchangeRateEntity>
{
    public ExchangeRateId Id { get; private init; }

    public string Currency { get; private init; }

    public DateTime From { get; private init; }

    public DateTime To { get; private init; }

    public string OrderBy { get; private init; }

    public bool IsDesc { get; private init; }

    public int Skip { get; private init; }

    public int Limit { get; private init; }

    public static ExchangeRateFilter Create()
    {
        return new ExchangeRateFilter();
    }

    private ExchangeRateFilter()
    {

    }

    public ExchangeRateFilter WithCurrency(string currency)
    {
        return this with
        {
            Currency = currency
        };
    }

    public ExchangeRateFilter WithFromDate(DateTime from)
    {
        return this with
        {
            From = from
        };
    }

    public ExchangeRateFilter WithToDate(DateTime to)
    {
        return this with
        {
            To = to
        };
    }

    public ExchangeRateFilter WithId(string id)
    {
        return this with
        {
            Id = new ExchangeRateId(id)
        };
    }

    public IPagedFilter<ExchangeRateEntity> WithPaging(int skip, int limit)
    {
        return this with
        {
            Skip = skip,
            Limit = limit
        };
    }

    public IPagedFilter<ExchangeRateEntity> WithOrderBy(string OrderBy, bool isDesc = false)
    {
        return this with
        {
            OrderBy = OrderBy,
            IsDesc = isDesc
        };
    }
}