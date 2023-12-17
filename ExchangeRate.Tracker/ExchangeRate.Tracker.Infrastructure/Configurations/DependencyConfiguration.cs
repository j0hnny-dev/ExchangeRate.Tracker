using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.Currencies;
using ExchangeRate.Tracker.Infrastructure.Currencies;
using ExchangeRate.Tracker.Infrastructure.Proxies;
using ExchangeRate.Tracker.MNBServices;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.Tracker.Infrastructure.Configurations;

public static class DependencyConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMnbServices();
        services.AddDbContext<ExchangeRateDbContext>(ServiceLifetime.Scoped);

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ICurrencyProxy, CurrencyProxy>();
        services.AddScoped<IMnbExchangeRateProxy, MnbExchangeRateProxy>();

        services.AddAutoMapper(typeof(InfrastuctureMapperConfig));
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new InfrastuctureMapperConfig());
        });

        return services;
    }
}
