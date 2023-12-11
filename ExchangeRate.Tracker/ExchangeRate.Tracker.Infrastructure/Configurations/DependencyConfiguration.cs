using AutoMapper.Extensions.ExpressionMapping;
using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.Infrastructure.Repositories;
using ExchangeRate.Tracker.MNBServices;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRate.Tracker.Infrastructure.Configurations;

public static class DependencyConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMnbServices();
        services.AddDbContext<ExchangeRateDbContext>(ServiceLifetime.Scoped);

        services.AddScoped<IRepository<ExchangeRateEntity>, ExchangeRateRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddAutoMapper(typeof(InfrastuctureMapperConfig));
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new InfrastuctureMapperConfig());
            cfg.AddExpressionMapping();
        });

        return services;
    }
}
