using ExchangeRate.Tracker.Domain.Currencies;
using ExchangeRate.Tracker.MNBServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRate.Tracker.Infrastructure.Currencies;

public class CurrencyProxy : ICurrencyProxy
{
    private readonly IExchangeRateProxy _exchangeRateProxy;

    public CurrencyProxy(IExchangeRateProxy exchangeRateProxy)
    {
        _exchangeRateProxy = exchangeRateProxy;
    }

    public async Task<IReadOnlyList<Currency>> GetCurrenciesAsync()
    {
        var currencyData = await _exchangeRateProxy.GetCurrenciesAsync().ConfigureAwait(false);
        return currencyData.Currencies.Select(x => new Currency(x)).ToList();
    }
}
