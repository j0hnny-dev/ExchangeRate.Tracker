using ExchangeRate.Tracker.ApplicationService.Currencies;

namespace ExchangeRate.Tracker.ApplicationService.Contracts;

public interface ICurrencyService
{
    Task<IReadOnlyList<CurrencyDto>> GetAllAsync();
}
