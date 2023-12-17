using ExchangeRate.Tracker.Domain.Base;

namespace ExchangeRate.Tracker.Domain.ExchangeRates;

public interface IEntityId : IValueObject
{
    string Value { get; }
}
