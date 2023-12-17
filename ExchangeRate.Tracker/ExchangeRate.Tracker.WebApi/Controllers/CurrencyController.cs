using ExchangeRate.Tracker.ApplicationService.Contracts;
using ExchangeRate.Tracker.ApplicationService.Currencies;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.Tracker.WebApi.Controllers;

[Route("currencies")]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        this._currencyService = currencyService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CurrencyDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetAllAsync()
    {
        var currencies = await _currencyService.GetAllAsync().ConfigureAwait(false);
        return Ok(currencies);
    }
}
