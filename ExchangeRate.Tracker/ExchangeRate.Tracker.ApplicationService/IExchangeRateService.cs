using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.ExchangeRates;

namespace ExchangeRate.Tracker.ApplicationService;

public interface IExchangeRateService
{
    Task<ExchangeRateDto> AddAsync(ExchangeRateDto exchangeRateDto);

    Task<ExchangeRateDto> UpdateAsync(ExchangeRateDto exchangeRateDto);

    Task<ExchangeRateDto> GetByFilter(IFilter<ExchangeRateEntity> filter);

    Task<IReadOnlyList<ExchangeRateDto>> GetAllByFilter(IFilter<ExchangeRateEntity> filter);
}
