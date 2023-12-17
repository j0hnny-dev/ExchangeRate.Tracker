using ExchangeRate.Tracker.ApplicationService.Contracts;
using ExchangeRate.Tracker.ApplicationService.Currencies;
using ExchangeRate.Tracker.ApplicationService.ExchangeRates;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.Tracker.ApplicationService.Configurations;

public static class DependencyConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IExchangeRateService, ExchangeRateService>();
        services.AddScoped<ICurrencyService, CurrencyService>();

        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new ApplicationServiceMapperConfiguration());
        });

        return services;
    }
}
