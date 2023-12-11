namespace ExchangeRate.Tracker.WebApi.Models;

public record GetExchangeRequest
{
    public string Currency { get; init; }

    public DateTimeOffset From { get; init; }

    public DateTimeOffset To { get; init; }
}
