namespace ExchangeRate.Tracker.ApplicationService;

public class ExchangeRateDto
{
    public Guid Id { get; set; }

    public DateTime Day { get; init; }

    public string Currency { get; init; }

    public decimal Value { get; init; }

    public string Comment { get; init; }
}
