using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.Infrastructure.Models;
using System;
using System.Linq.Expressions;

namespace ExchangeRate.Tracker.Infrastructure.Repositories;

internal static class ExchangeRateFilterBuilder
{
    public static Expression<Func<ExchangeRateStoreModel, bool>> GetFilterExpression(this ExchangeRateFilter exchangeRateFilter)
    {
        return rate => string.IsNullOrWhiteSpace(exchangeRateFilter.Currency) == false && exchangeRateFilter.Currency.ToLowerInvariant() == rate.Currency &&
                        string.IsNullOrWhiteSpace(exchangeRateFilter.Id.Value) == false && int.Parse(exchangeRateFilter.Id.Value) == rate.Id &&
                        exchangeRateFilter.From != DateTime.MinValue && exchangeRateFilter.From <= rate.TradingDate &&
                        exchangeRateFilter.To != DateTime.MinValue && exchangeRateFilter.To >= rate.TradingDate;

    }

    public static Expression<Func<ExchangeRateStoreModel, object>> GetOrderByExpression(this ExchangeRateFilter exchangeRateFilter)
    {
        if (exchangeRateFilter.OrderBy.Equals(nameof(ExchangeRateStoreModel.Currency), StringComparison.InvariantCultureIgnoreCase))
        {
            return rate => rate.Currency;
        }

        if (exchangeRateFilter.OrderBy.Equals(nameof(ExchangeRateStoreModel.Value), StringComparison.InvariantCultureIgnoreCase))
        {
            return rate => rate.Value;
        }

        if (exchangeRateFilter.OrderBy.Equals(nameof(ExchangeRateStoreModel.Unit), StringComparison.InvariantCultureIgnoreCase))
        {
            return rate => rate.Unit;
        }

        return rate => rate.TradingDate;
    }
}
