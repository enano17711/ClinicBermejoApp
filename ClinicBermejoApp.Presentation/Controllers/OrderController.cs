using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Orders;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IServiceManager _service;

    public OrderController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetOrders")]
    public async Task<IActionResult> GetOrders([FromQuery] OrderParameters parameters)
    {
        var pagedResult = await _service.OrderService.GetOrdersAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.orders);
    }

    [HttpGet("{id:guid}", Name = "GetOrderById")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var order = await _service.OrderService.GetOrderByIdAsync(id, false);
        return Ok(order);
    }

    [HttpPost(Name = "CreateOrder")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto order)
    {
        var createOrder = await _service.OrderService.CreateOrderAsync(order);
        return CreatedAtRoute("GetOrderById", new { id = createOrder.Id }, createOrder);
    }

    [HttpDelete("{id:guid}", Name = "DeleteOrder")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        await _service.OrderService.DeleteOrderAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateOrder")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderForUpdateDto order)
    {
        await _service.OrderService.UpdateOrderAsync(id, order, true);
        return NoContent();
    }
}