namespace ExchangeRate.Tracker.Infrastructure.Configurations;

public sealed record DbConnectionConfiguration
{
    public const string SectionName = nameof(DbConnectionConfiguration);

    public string Server { get; init; }

    public int Port { get; init; }

    public string Database { get; init; }

    public string User { get; init; }

    public string Password { get; init; }

    public string ConnectionString => $"server={Server},{Port};Database={Database};Integrated Security=False;MultipleActiveResultSets=true;User Id={User};Password={Password};";
}
