using System.Diagnostics.CodeAnalysis;

namespace ExchangeRate.Tracker.Domain.ExchangeRates;

public record ExchangeRateId(string Value) : IEntityId, IEqualityComparer<ExchangeRateId>
{
    public static ExchangeRateId Undefinied => new(string.Empty);

    public bool Equals(ExchangeRateId? x, ExchangeRateId? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }
        if (x is null)
        {
            return false;
        }
        if (y is null)
        {
            return false;
        }

        return x.Value.Equals(y.Value, StringComparison.InvariantCultureIgnoreCase);
    }

    public int GetHashCode([DisallowNull] ExchangeRateId obj)
    {
        return base.GetHashCode();
    }
}
