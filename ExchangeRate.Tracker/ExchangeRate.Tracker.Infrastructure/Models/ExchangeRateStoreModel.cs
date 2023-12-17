using System;

namespace ExchangeRate.Tracker.Infrastructure.Models;

internal class ExchangeRateStoreModel
{
    public int Id { get; init; }

    public DateTime Store { get; init; }

    public DateTime TradingDate { get; init; }

    public string Currency { get; init; }

    public decimal Value { get; init; }

    public double Unit { get; init; }

    public string Comment { get; init; }
}
