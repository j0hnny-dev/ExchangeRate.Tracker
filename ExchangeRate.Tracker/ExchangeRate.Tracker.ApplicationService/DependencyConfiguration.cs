namespace ExchangeRate.Tracker.ApplicationService;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IExchangeRateService, ExchangeRateService>();

        return services;
    }
}
