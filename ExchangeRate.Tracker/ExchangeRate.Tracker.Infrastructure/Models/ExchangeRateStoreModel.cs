using System;

namespace ExchangeRate.Tracker.Infrastructure.Models;

internal class ExchangeRateStoreModel
{
    public int Id { get; init; }

    public DateTime StoreDate { get; init; }

    public string Currency { get; init; }

    public decimal Value { get; init; }

    public string Comment { get; init; }
}
