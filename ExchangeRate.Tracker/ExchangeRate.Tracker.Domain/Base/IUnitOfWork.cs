using ExchangeRate.Tracker.Domain.ExchangeRates;

namespace ExchangeRate.Tracker.Domain.Base;

public interface IUnitOfWork
{
    IRepository<ExchangeRateEntity> ExchangeRateRepository { get; }

    Task<bool> SaveAsync();
}
