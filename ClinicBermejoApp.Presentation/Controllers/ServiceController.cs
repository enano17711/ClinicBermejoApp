using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.Services;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServiceManager _service;

    public ServiceController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetServices")]
    public async Task<IActionResult> GetServices([FromQuery] ServiceParameters parameters)
    {
        var pagedResult = await _service.ServiceService.GetServicesAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.services);
    }

    [HttpGet("{id:guid}", Name = "GetServiceById")]
    public async Task<IActionResult> GetServiceById(Guid id)
    {
        var service = await _service.ServiceService.GetServiceByIdAsync(id, false);
        return Ok(service);
    }

    [HttpPost(Name = "CreateService")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateService([FromBody] ServiceForCreationDto service)
    {
        var createService = await _service.ServiceService.CreateServiceAsync(service);
        return CreatedAtRoute("GetServiceById", new { id = createService.Id }, createService);
    }

    [HttpDelete("{id:guid}", Name = "DeleteService")]
    public async Task<IActionResult> DeleteService(Guid id)
    {
        await _service.ServiceService.DeleteServiceAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateService")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateService(Guid id, [FromBody] ServiceForUpdateDto service)
    {
        await _service.ServiceService.UpdateServiceAsync(id, service, true);
        return NoContent();
    }
}