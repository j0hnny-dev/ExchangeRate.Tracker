using ExchangeRate.Tracker.MNBServices.Models;
using System;
using System.Threading.Tasks;

namespace ExchangeRate.Tracker.MNBServices
{
    public interface IExchangeRateProxy
    {
        Task<CurrencyData> GetCurrenciesAsync();

        Task<CurrentExchangeRatesData> GetCurrentExchangesAsync();

        Task<ExchangeRatesData> GetExchangeRateAsync(string currencyName, DateTime start, DateTime end);
    }
}
