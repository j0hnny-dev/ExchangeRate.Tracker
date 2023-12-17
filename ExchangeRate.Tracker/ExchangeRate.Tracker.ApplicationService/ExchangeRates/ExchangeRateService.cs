using AutoMapper;
using ExchangeRate.Tracker.ApplicationService.Contracts;
using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.ExchangeRates;

namespace ExchangeRate.Tracker.ApplicationService.ExchangeRates;

internal class ExchangeRateService : IExchangeRateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ExchangeRateService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IExchangeRate> AddAsync(IExchangeRate exchangeRateDto)
    {
        var entity = _mapper.Map<ExchangeRateEntity>(exchangeRateDto);

        var saved = await _unitOfWork.ExchangeRateRepository.AddAsync(entity).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<ExchangeRateDto>(saved);
    }

    public async Task<IExchangeRate> UpdateAsync(IExchangeRate exchangeRateDto)
    {
        var oldModel = await _unitOfWork.ExchangeRateRepository.GetByAsync(new ExchangeRateId(exchangeRateDto.Id.ToString())).ConfigureAwait(false);
        if (oldModel.Equals(ExchangeRateEntity.Empty))
        {
            return ExchangeRateDto.None;
        }

        var entity = _mapper.Map(exchangeRateDto, oldModel);

        var saved = await _unitOfWork.ExchangeRateRepository.UpdateAsync(entity).ConfigureAwait(false);

        await _unitOfWork.SaveAsync().ConfigureAwait(false);

        return _mapper.Map<ExchangeRateDto>(saved);
    }

    public async Task<IExchangeRate> GetByFilter(IPagedFilter<ExchangeRateEntity> filter)
    {
        var entity = await _unitOfWork.ExchangeRateRepository.FindByAsync(filter).ConfigureAwait(false);
        if (entity.Equals(ExchangeRateEntity.Empty))
        {
            return ExchangeRateDto.None;
        }

        return _mapper.Map<ExchangeRateDto>(entity);
    }

    public async Task<IReadOnlyList<IExchangeRate>> GetAllByFilter(IPagedFilter<ExchangeRateEntity> filter)
    {
        var entities = await _unitOfWork.ExchangeRateRepository.FilterByAsync(filter).ConfigureAwait(false);

        return entities.Select(_mapper.Map<ExchangeRateDto>).ToList();
    }
}
