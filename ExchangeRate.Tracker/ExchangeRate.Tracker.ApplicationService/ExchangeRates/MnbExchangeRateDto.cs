using ExchangeRate.Tracker.ApplicationService.Contracts;

namespace ExchangeRate.Tracker.ApplicationService.ExchangeRates;

public record MnbExchangeRateDto : IMnbExchangeRate
{
    public DateTime Day { get; init; }

    public string Currency { get; init; }

    public decimal Value { get; init; }

    public double Unit { get; init; }

}
