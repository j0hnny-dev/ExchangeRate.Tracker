using ExchangeRate.Tracker.ApplicationService.Contracts;
using System.Text.Json.Serialization;

namespace ExchangeRate.Tracker.WebApi.Models;

public record CreateExchangeRequest : IExchangeRate
{
    public string Currency { get; init; }

    public DateTime Day { get; init; }

    public decimal Value { get; init; }

    public double Unit { get; init; }

    public string Comment { get; init; }

    [JsonIgnore]
    public int Id => 0;
}
