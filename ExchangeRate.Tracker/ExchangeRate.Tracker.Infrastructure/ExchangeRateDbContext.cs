using ExchangeRate.Tracker.Infrastructure.Configurations;
using ExchangeRate.Tracker.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace ExchangeRate.Tracker.Infrastructure;

internal class ExchangeRateDbContext : DbContext
{
    private readonly string _connectionString;

    public virtual DbSet<ExchangeRateStoreModel> ExchangesRates { get; set; }

    public ExchangeRateDbContext(IOptions<DbConnectionConfiguration> options)
    {
        _connectionString = options.Value.ConnectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlServer(_connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                builder.MigrationsAssembly(typeof(ExchangeRateDbContext).Assembly.GetName().Name);
            });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExchangeRateDbContext).Assembly);
    }
}
