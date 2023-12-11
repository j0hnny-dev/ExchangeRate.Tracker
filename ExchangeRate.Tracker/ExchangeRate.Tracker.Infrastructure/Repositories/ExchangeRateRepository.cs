using AutoMapper;
using ExchangeRate.Tracker.Domain.Base;
using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExchangeRate.Tracker.Infrastructure.Repositories;

internal class ExchangeRateRepository : IRepository<ExchangeRateEntity>
{
    private readonly IMapper _mapper;
    private readonly DbSet<ExchangeRateStoreModel> _exchangeRates;

    public ExchangeRateRepository(DbContext dbContext, IMapper mapper)
    {
        _exchangeRates = dbContext.Set<ExchangeRateStoreModel>();
        _mapper = mapper;
    }

    public async Task<ExchangeRateEntity> AddAsync(ExchangeRateEntity entity)
    {
        var storeModel = _mapper.Map<ExchangeRateStoreModel>(entity);

        var saved = await _exchangeRates.AddAsync(storeModel).ConfigureAwait(false);

        return _mapper.Map<ExchangeRateEntity>(saved);
    }

    public async Task<IReadOnlyList<ExchangeRateEntity>> FilterByAsync(IFilter<ExchangeRateEntity> filter)
    {
        var query = _exchangeRates
            .Where(_mapper.Map<Expression<Func<ExchangeRateStoreModel, bool>>>(filter.Filter))
            .Skip(filter.Skip)
            .Take(filter.Limit);

        if (string.IsNullOrEmpty(filter.OrderBy))
        {
            // TODO: Expression
            var orderByExpression = _mapper.Map<Expression<Func<ExchangeRateStoreModel, string>>>(filter.OrderBy);
            query = filter.IsDesc ? query.OrderByDescending(orderByExpression) : query.OrderBy(orderByExpression);
        }

        var result = await query.ToListAsync().ConfigureAwait(false);

        return result.Select(_mapper.Map<ExchangeRateEntity>).ToList();
    }

    public async Task<IReadOnlyList<ExchangeRateEntity>> GetAllAsync()
    {
        var storeModels = await _exchangeRates.ToListAsync().ConfigureAwait(false);

        return storeModels.Select(_mapper.Map<ExchangeRateEntity>).ToList();
    }

    public async Task<ExchangeRateEntity> FindByAsync(Expression<Func<ExchangeRateEntity, bool>> filter)
    {
        var storeModel = await _exchangeRates.FindAsync(_mapper.Map<Expression<Func<ExchangeRateStoreModel, bool>>>(filter));

        return _mapper.Map<ExchangeRateEntity>(storeModel);
    }

    public async Task<ExchangeRateEntity> UpdateAsync(ExchangeRateEntity entity)
    {
        var storeModel = _mapper.Map<ExchangeRateStoreModel>(entity);

        var entry = _exchangeRates.Update(storeModel);

        await entry.ReloadAsync().ConfigureAwait(false);

        return _mapper.Map<ExchangeRateEntity>(entry.Entity);
    }
}
