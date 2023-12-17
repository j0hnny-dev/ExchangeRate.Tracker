using ExchangeRate.Tracker.Domain.ExchangeRates;

namespace ExchangeRate.Tracker.Infrastructure;

public interface IMnbExchangeRateProxy
{
    Task<IReadOnlyList<ExchangeRateEntity>> GetExchangeRatesAsync(ExchangeRateFilter exchangeRateFilter);
}
