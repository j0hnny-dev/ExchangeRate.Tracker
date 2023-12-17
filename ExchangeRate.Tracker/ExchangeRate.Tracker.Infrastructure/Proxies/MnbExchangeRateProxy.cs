using ExchangeRate.Tracker.Domain.Currencies;
using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.MNBServices;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRate.Tracker.Infrastructure.Proxies;

public class MnbExchangeRateProxy : IMnbExchangeRateProxy
{
    private static readonly CultureInfo HunCultureInfo = new("HU");
    private readonly IExchangeRateProxy _exchangeRateProxy;

    public MnbExchangeRateProxy(IExchangeRateProxy exchangeRateProxy)
    {
        _exchangeRateProxy = exchangeRateProxy;
    }

    public async Task<IReadOnlyList<ExchangeRateEntity>> GetExchangeRatesAsync(ExchangeRateFilter exchangeRateFilter)
    {
        var data = await _exchangeRateProxy.GetExchangeRateAsync(exchangeRateFilter.Currency, exchangeRateFilter.From, exchangeRateFilter.To).ConfigureAwait(false);
        if (data == null)
        {
            return new List<ExchangeRateEntity>();
        }

        var exchangeRates = data.DaysData
            .SelectMany(data => data.Rates.Select(rate => new ExchangeRateEntity
            {
                Currency = new Currency(rate.Currency),
                Value = decimal.TryParse(rate.Value, NumberStyles.AllowDecimalPoint, HunCultureInfo, out var value) ? value : 0,
                Unit = double.TryParse(rate.Unit, NumberStyles.AllowDecimalPoint, HunCultureInfo, out var unit) ? unit : 0,
                TradingDate = data.Date
            }))
            .ToList();

        return exchangeRates;
    }
}