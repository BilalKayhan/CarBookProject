﻿using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PricingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PricingsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> PricingList()
    {
        var values = await _mediator.Send(new GetPricingQuery());
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPricing(int id)
    {
        var values = await _mediator.Send(new GetPricingByIdQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
    {
        await _mediator.Send(command);
        return Ok("Ödeme Türü Başarıyla Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> RemovePricing(int id)
    {
        await _mediator.Send(new RemovePricingCommand(id));
        return Ok("Ödeme Türü Başarıyla Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
    {
        await _mediator.Send(command);
        return Ok("Ödeme Türü Başarıyla Güncellendi.");
    }
}
