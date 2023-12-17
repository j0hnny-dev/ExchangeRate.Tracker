namespace ExchangeRate.Tracker.ApplicationService.Contracts;

public interface IMnbExchangeRate
{
    DateTime Day { get; }

    string Currency { get; }

    decimal Value { get; }

    double Unit { get; }
}
