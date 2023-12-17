using AutoMapper;
using ExchangeRate.Tracker.ApplicationService.Contracts;
using ExchangeRate.Tracker.Domain.Currencies;

namespace ExchangeRate.Tracker.ApplicationService.Currencies;

internal class CurrencyService : ICurrencyService
{
    private readonly ICurrencyProxy _currencyProxy;
    private readonly IMapper _mapper;

    public CurrencyService(ICurrencyProxy currencyProxy, IMapper mapper)
    {
        _currencyProxy = currencyProxy;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CurrencyDto>> GetAllAsync()
    {
        var currencies = await _currencyProxy.GetCurrenciesAsync().ConfigureAwait(false);

        return currencies.Select(_mapper.Map<CurrencyDto>).ToList();
    }
}
