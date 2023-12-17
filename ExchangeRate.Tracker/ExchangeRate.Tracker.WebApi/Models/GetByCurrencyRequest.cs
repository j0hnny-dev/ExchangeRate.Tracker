using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRate.Tracker.WebApi.Models;

public record GetByCurrencyRequest
{
    /// <example>EUR</example>
    [FromQuery, Required]
    public string Currency { get; init; }

    /// <example>2023-12-12</example>
    [FromQuery]
    public DateTime From { get; init; }

    /// <example>2023-12-12</example>
    [FromQuery]
    public DateTime To { get; init; }
}