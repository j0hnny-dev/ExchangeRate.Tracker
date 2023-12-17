namespace ExchangeRate.Tracker.ApplicationService.Contracts;

public interface IExchangeRate : IMnbExchangeRate
{
    int Id { get; }

    string Comment { get; }
}
