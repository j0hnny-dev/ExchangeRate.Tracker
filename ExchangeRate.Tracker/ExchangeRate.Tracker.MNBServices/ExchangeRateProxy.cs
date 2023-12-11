using ExchangeRate.Tracker.MNBServices.Models;
using MnbExchnageRateService;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRate.Tracker.MNBServices
{
    internal class ExchangeRateProxy : IExchangeRateProxy
    {
        private readonly MNBArfolyamServiceSoap exchangeRateSoapClient;

        public ExchangeRateProxy(MNBArfolyamServiceSoap exchangeRateSoapClient)
        {
            this.exchangeRateSoapClient = exchangeRateSoapClient;
        }

        public async Task<CurrencyData> GetCurrenciesAsync()
        {
            var request = new GetCurrenciesRequest
            {
                GetCurrencies = new GetCurrenciesRequestBody()
            };

            var rawXml = await exchangeRateSoapClient.GetCurrenciesAsync(request).ConfigureAwait(false);

            var currencyData = GetObject<CurrencyData>(rawXml.GetCurrenciesResponse1.GetCurrenciesResult);

            return currencyData;
        }

        public async Task<ExchangeRatesData> GetExchangeRateAsync(string currencyName, DateTime start, DateTime end)
        {
            var request = new GetExchangeRatesRequest
            {
                GetExchangeRates = new GetExchangeRatesRequestBody
                {
                    currencyNames = currencyName,
                    startDate = start.Date.ToShortDateString(),
                    endDate = end.Date.ToShortDateString()
                }
            };

            var exchange = await exchangeRateSoapClient.GetExchangeRatesAsync(request).ConfigureAwait(false);

            var rawXml = exchange.GetExchangeRatesResponse1?.GetExchangeRatesResult ?? string.Empty;

            return GetObject<ExchangeRatesData>(rawXml);
        }

        public async Task<CurrentExchangeRatesData> GetCurrentExchangesAsync()
        {
            var request = new GetCurrentExchangeRatesRequest { GetCurrentExchangeRates = new GetCurrentExchangeRatesRequestBody { } };
            var exchangeRates = await exchangeRateSoapClient.GetCurrentExchangeRatesAsync(request).ConfigureAwait(false);

            var rawXml = exchangeRates.GetCurrentExchangeRatesResponse1.GetCurrentExchangeRatesResult ?? string.Empty;

            return GetObject<CurrentExchangeRatesData>(rawXml);
        }

        private TObject GetObject<TObject>(string data) where TObject : class
        {
            var serializer = new XmlSerializer(typeof(TObject));

            using StringReader reader = new StringReader(data);

            return (TObject)serializer.Deserialize(reader);
        }
    }
}
