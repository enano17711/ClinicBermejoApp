using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DetailOrders;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DetailOrderController : ControllerBase
{
    private readonly IServiceManager _service;

    public DetailOrderController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetDetailOrders")]
    public async Task<IActionResult> GetDetailOrders([FromQuery] DetailOrderParameters parameters)
    {
        var pagedResult = await _service.DetailOrderService.GetDetailOrdersAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.detailOrders);
    }

    [HttpGet("{id:guid}", Name = "GetDetailOrderById")]
    public async Task<IActionResult> GetDetailOrderById(Guid id)
    {
        var detailOrder = await _service.DetailOrderService.GetDetailOrderByIdAsync(id, false);
        return Ok(detailOrder);
    }

    [HttpPost(Name = "CreateDetailOrder")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateDetailOrder([FromBody] DetailOrderForCreationDto detailOrder)
    {
        var createDetailOrder = await _service.DetailOrderService.CreateDetailOrderAsync(detailOrder);
        return CreatedAtRoute("GetDetailOrderById", new { id = createDetailOrder.Id }, createDetailOrder);
    }

    [HttpDelete("{id:guid}", Name = "DeleteDetailOrder")]
    public async Task<IActionResult> DeleteDetailOrder(Guid id)
    {
        await _service.DetailOrderService.DeleteDetailOrderAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateDetailOrder")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateDetailOrder(Guid id, [FromBody] DetailOrderForUpdateDto detailOrder)
    {
        await _service.DetailOrderService.UpdateDetailOrderAsync(id, detailOrder, true);
        return NoContent();
    }
}