using ExchangeRate.Tracker.ApplicationService.Contracts;

namespace ExchangeRate.Tracker.ApplicationService.ExchangeRates;

public record ExchangeRateDto : IExchangeRate
{
    public static ExchangeRateDto None => new()
    {
        Id = 0,
        Day = DateTime.MinValue,
        Currency = string.Empty,
        Value = 0,
        Comment = string.Empty,
    };

    public int Id { get; init; }

    public DateTime Day { get; init; }

    public string Currency { get; init; }

    public decimal Value { get; init; }

    public double Unit { get; init; }

    public string Comment { get; init; }
}
