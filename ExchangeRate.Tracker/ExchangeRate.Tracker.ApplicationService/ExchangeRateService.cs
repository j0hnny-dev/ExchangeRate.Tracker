using AutoMapper;
using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.ExchangeRates;

namespace ExchangeRate.Tracker.ApplicationService;

public class ExchangeRateService : IExchangeRateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExchangeRateService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ExchangeRateDto> AddAsync(ExchangeRateDto exchangeRateDto)
    {
        var entity = _mapper.Map<ExchangeRateEntity>(exchangeRateDto);

        var saved = await _unitOfWork.ExchangeRateRepository.AddAsync(entity).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<ExchangeRateDto>(saved);
    }

    public async Task<ExchangeRateDto> UpdateAsync(ExchangeRateDto exchangeRateDto)
    {
        var entity = _mapper.Map<ExchangeRateEntity>(exchangeRateDto);

        var saved = await _unitOfWork.ExchangeRateRepository.UpdateAsync(entity).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<ExchangeRateDto>(saved);
    }

    public async Task<ExchangeRateDto> GetByFilter(IFilter<ExchangeRateEntity> filter)
    {
        var entity = await _unitOfWork.ExchangeRateRepository.FindByAsync(filter.Filter).ConfigureAwait(false);

        return _mapper.Map<ExchangeRateDto>(entity);
    }

    public async Task<IReadOnlyList<ExchangeRateDto>> GetAllByFilter(IFilter<ExchangeRateEntity> filter)
    {
        var entities = await _unitOfWork.ExchangeRateRepository.FilterByAsync(filter).ConfigureAwait(false);

        return entities.Select(_mapper.Map<ExchangeRateDto>).ToList();
    }
}
