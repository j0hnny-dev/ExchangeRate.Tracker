using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.ExchangeRates;

namespace ExchangeRate.Tracker.ApplicationService.Contracts;

public interface IExchangeRateService
{
    Task<IExchangeRate> AddAsync(IExchangeRate exchangeRateDto);

    Task<IExchangeRate> UpdateAsync(IExchangeRate exchangeRateDto);

    Task<IExchangeRate> GetByFilter(IPagedFilter<ExchangeRateEntity> filter);

    Task<IReadOnlyList<IExchangeRate>> GetAllByFilter(IPagedFilter<ExchangeRateEntity> filter);
}
