using ExchangeRate.Tracker.ApplicationService.Contracts;
using ExchangeRate.Tracker.ApplicationService.ExchangeRates;
using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.Infrastructure;
using ExchangeRate.Tracker.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRate.Tracker.WebApi.Controllers;

[Route("/mnb-exchange-rates")]
[ApiController]
public class MnbExchangeRateContoller : ControllerBase
{
    private readonly IMnbExchangeRateProxy _exchangeRateProxy;

    public MnbExchangeRateContoller(IMnbExchangeRateProxy exchangeRateProxy)
    {
        _exchangeRateProxy = exchangeRateProxy;
    }

    [HttpGet(Name = "GetByCurrency")]
    public async Task<ActionResult<IEnumerable<IMnbExchangeRate>>> GetByCurrencyAsync([FromQuery, Required] GetByCurrencyRequest request)
    {
        var filter = ExchangeRateFilter.Create()
            .WithCurrency(request.Currency)
            .WithFromDate(request.From)
            .WithToDate(request.To);

        var entities = await _exchangeRateProxy.GetExchangeRatesAsync(filter).ConfigureAwait(false);
        var exchangeRates = entities.Select(x => new MnbExchangeRateDto
        {
            Day = x.TradingDate,
            Currency = x.Currency.Name,
            Unit = x.Unit,
            Value = x.Value,
        });

        return Ok(exchangeRates);
    }
}
