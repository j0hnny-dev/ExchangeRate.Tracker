using AutoMapper;
using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRate.Tracker.Infrastructure.Repositories;

internal class ExchangeRateRepository : IRepository<ExchangeRateEntity>
{
    private readonly IMapper _mapper;
    private readonly DbSet<ExchangeRateStoreModel> _exchangeRates;

    public ExchangeRateRepository(ExchangeRateDbContext dbContext, IMapper mapper)
    {
        _exchangeRates = dbContext.ExchangesRates;
        _mapper = mapper;
    }

    public async Task<ExchangeRateEntity> AddAsync(ExchangeRateEntity entity)
    {
        var storeModel = _mapper.Map<ExchangeRateStoreModel>(entity);

        var saved = await _exchangeRates.AddAsync(storeModel).ConfigureAwait(false);

        return _mapper.Map<ExchangeRateEntity>(saved);
    }

    public async Task<ExchangeRateEntity> UpdateAsync(ExchangeRateEntity entity)
    {
        var storeModel = _mapper.Map<ExchangeRateStoreModel>(entity);

        var entry = _exchangeRates.Update(storeModel);

        await entry.ReloadAsync().ConfigureAwait(false);

        return _mapper.Map<ExchangeRateEntity>(entry.Entity);
    }

    public async Task<IReadOnlyList<ExchangeRateEntity>> GetAllAsync()
    {
        var storeModels = await _exchangeRates.ToListAsync().ConfigureAwait(false);

        return storeModels.Select(_mapper.Map<ExchangeRateEntity>).ToList();
    }

    public async Task<ExchangeRateEntity> GetByAsync<TEntityId>(TEntityId id) where TEntityId : class, IEntityId
    {
        var storeId = int.Parse(id.Value);

        var storeModel = await _exchangeRates.FirstOrDefaultAsync(x => x.Id == storeId).ConfigureAwait(false);
        if (storeModel == null)
        {
            return ExchangeRateEntity.Empty;
        }

        return _mapper.Map<ExchangeRateEntity>(storeModel);
    }

    public async Task<ExchangeRateEntity> FindByAsync(IPagedFilter<ExchangeRateEntity> filter)
    {
        var filterExpression = ((ExchangeRateFilter)filter).GetFilterExpression();

        var storeModel = await _exchangeRates.FindAsync(filterExpression).ConfigureAwait(false);
        if (storeModel == null)
        {
            return ExchangeRateEntity.Empty;
        }

        return _mapper.Map<ExchangeRateEntity>(storeModel);
    }

    public async Task<IReadOnlyList<ExchangeRateEntity>> FilterByAsync(IPagedFilter<ExchangeRateEntity> filter)
    {
        var query = _exchangeRates
            .Where(((ExchangeRateFilter)filter).GetFilterExpression())
            .Skip(filter.Skip)
            .Take(filter.Limit);

        if (string.IsNullOrEmpty(filter.OrderBy))
        {
            var orderByExpression = ((ExchangeRateFilter)filter).GetOrderByExpression();
            query = filter.IsDesc ? query.OrderByDescending(orderByExpression) : query.OrderBy(orderByExpression);
        }

        var result = await query.ToListAsync().ConfigureAwait(false);

        return result.Select(_mapper.Map<ExchangeRateEntity>).ToList();
    }
}
