using ExchangeRate.Tracker.Domain.Base;

namespace ExchangeRate.Tracker.Domain.Currencies;

public record Currency(string Name) : IEntity
{
    public static Currency Empty => new(string.Empty);
}
