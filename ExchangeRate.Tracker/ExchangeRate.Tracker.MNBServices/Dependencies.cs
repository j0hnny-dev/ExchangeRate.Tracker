using Microsoft.Extensions.DependencyInjection;
using MnbExchnageRateService;

namespace ExchangeRate.Tracker.MNBServices
{
    public static class Dependencies
    {
        public static IServiceCollection AddMnbServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<MNBArfolyamServiceSoap, MNBArfolyamServiceSoapClient>();
            serviceCollection.AddScoped<IExchangeRateProxy, ExchangeRateProxy>();

            return serviceCollection;
        }
    }
}
