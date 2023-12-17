using ExchangeRate.Tracker.ApplicationService.Contracts;

namespace ExchangeRate.Tracker.WebApi.Models;

public class UpdateExchangeRequest : IExchangeRate
{
    public int Id { get; init; }

    public string Currency { get; init; }

    public DateTime Day { get; init; }

    public decimal Value { get; init; }

    public double Unit { get; init; }

    public string Comment { get; init; }
}
