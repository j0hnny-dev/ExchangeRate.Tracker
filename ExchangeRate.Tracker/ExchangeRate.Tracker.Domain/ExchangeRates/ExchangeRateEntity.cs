using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.Currencies;

namespace ExchangeRate.Tracker.Domain.ExchangeRates;

public class ExchangeRateEntity : IAggregateRoot, IEntity
{
    public DateTime StoreDate { get; }

    public Currency Currency { get; init; }

    public decimal Value { get; init; }

    public string Comment { get; init; }

    private ExchangeRateEntity()
    {

    }

    public static ExchangeRateEntity Create(Currency currency, decimal value)
    {
        return new ExchangeRateEntity
        {
            Currency = currency,
            Value = value
        };
    }
}
