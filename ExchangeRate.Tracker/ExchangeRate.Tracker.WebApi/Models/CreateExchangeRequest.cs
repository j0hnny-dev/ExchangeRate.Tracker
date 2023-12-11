namespace ExchangeRate.Tracker.WebApi.Models;

public record CreateExchangeRequest
{
    public string Currency { get; init; }

    public DateTime Day { get; init; }

    public decimal Value { get; init; }

    public string Comment { get; init; }
}
