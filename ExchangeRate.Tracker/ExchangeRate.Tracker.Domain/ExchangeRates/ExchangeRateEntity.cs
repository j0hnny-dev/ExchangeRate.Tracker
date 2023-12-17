using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.Currencies;

namespace ExchangeRate.Tracker.Domain.ExchangeRates;

public class ExchangeRateEntity : IAggregateRoot, IEntity
{
    public static ExchangeRateEntity Empty => new()
    {
        Id = ExchangeRateId.Undefinied,
        TradingDate = DateTime.MinValue,
        Comment = string.Empty,
        Store = default,
        Value = 0,
        Currency = Currency.Empty
    };

    public ExchangeRateId Id { get; init; }

    public DateTime TradingDate { get; init;  }

    public DateTime? Store { get; init; }

    public Currency Currency { get; init; }

    public decimal Value { get; init; }

    public double Unit { get; init; }

    public string Comment { get; init; }
}
