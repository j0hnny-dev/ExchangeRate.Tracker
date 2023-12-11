namespace ExchangeRate.Tracker.WebApi.Models;

public record PagedRequest<TRequest> where TRequest : class
{
    public TRequest Request { get; init; }

    public int Skip { get; init; }

    public int Limit { get; init; }

    public string OrderBy { get; init; }

    public bool IsDesc { get; init; }
}
