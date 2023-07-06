using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Customers;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IServiceManager _service;

    public CustomerController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetCustomers")]
    public async Task<IActionResult> GetCustomers([FromQuery] CustomerParameters parameters)
    {
        var pagedResult = await _service.CustomerService.GetCustomersAsync(parameters, false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.customers);
    }

    [HttpGet("{id:guid}", Name = "GetCustomerById")]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        var customer = await _service.CustomerService.GetCustomerByIdAsync(id, false);
        return Ok(customer);
    }

    [HttpPost(Name = "CreateCustomer")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreationDto customer)
    {
        var createCustomer = await _service.CustomerService.CreateCustomerAsync(customer);
        return CreatedAtRoute("GetCustomerById", new { id = createCustomer.Id }, createCustomer);
    }

    [HttpDelete("{id:guid}", Name = "DeleteCustomer")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        await _service.CustomerService.DeleteCustomerAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateCustomer")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] CustomerForUpdateDto customer)
    {
        await _service.CustomerService.UpdateCustomerAsync(id, customer, true);
        return NoContent();
    }
}