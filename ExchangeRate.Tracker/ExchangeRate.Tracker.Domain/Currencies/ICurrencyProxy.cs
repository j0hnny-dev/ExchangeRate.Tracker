namespace ExchangeRate.Tracker.Domain.Currencies;

public interface ICurrencyProxy
{
    Task<IReadOnlyList<Currency>> GetCurrenciesAsync();
}
