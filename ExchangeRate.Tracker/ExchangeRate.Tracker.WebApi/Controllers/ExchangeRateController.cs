using ExchangeRate.Tracker.ApplicationService;
using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExchangeRate.Tracker.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExchangeRateController : ControllerBase
{
    private readonly IExchangeRateService _exchangeRateService;

    public ExchangeRateController(IExchangeRateService exchangeRateService)
    {
        _exchangeRateService = exchangeRateService;
    }

    [HttpGet]
    public async Task<ActionResult<ExchangeRateDto>> GetAsync([FromQuery, Required] GetExchangeRequest request)
    {
        var filter = ExchangeRateFilter.Create(request.Currency);

        var result = await _exchangeRateService.GetByFilter(filter).ConfigureAwait(false);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost(Name = "GetAllByFilter")]
    public async Task<ActionResult<IReadOnlyList<ExchangeRateDto>>> GetAllByFilterAsync([FromBody, Required] PagedRequest<GetExchangeRequest> pagedRequest)
    {
        var filter = ExchangeRateFilter.Create(pagedRequest.Request.Currency)
            .WithPaging(pagedRequest.Skip, pagedRequest.Limit)
            .WithOrderBy(pagedRequest.OrderBy, pagedRequest.IsDesc);

        var result = await _exchangeRateService.GetAllByFilter(filter).ConfigureAwait(false);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ExchangeRateDto>> CreateAsync([FromBody, Required] CreateExchangeRequest createExchangeRequest)
    {
        if (ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var exchangeRateDto = new ExchangeRateDto
        {
            Value = createExchangeRequest.Value,
            Currency = createExchangeRequest.Currency,
            Comment = createExchangeRequest.Comment,
        };

        var created = await _exchangeRateService.AddAsync(exchangeRateDto).ConfigureAwait(false);

        return Created("", created);
    }

    [HttpPut]
    public async Task<ActionResult<ExchangeRateDto>> UpdateAsync([FromBody, Required] UpdateExchangeRequest exchangeRateRequest)
    {
        if (ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var exchangeRateDto = new ExchangeRateDto
        {
            Id = exchangeRateRequest.Id,
            Comment = exchangeRateRequest.Comment,
            Value = exchangeRateRequest.Value,
        };

        var saved = await _exchangeRateService.UpdateAsync(exchangeRateDto).ConfigureAwait(false);

        return Ok(saved);
    }
}
