using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.ServiceDoctors;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceDoctorController : ControllerBase
{
    private readonly IServiceManager _service;

    public ServiceDoctorController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetServiceDoctors")]
    public async Task<IActionResult> GetServiceDoctors([FromQuery] ServiceDoctorParameters parameters)
    {
        var pagedResult = await _service.ServiceDoctorService.GetServiceDoctorsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.serviceDoctors);
    }

    [HttpGet("{id:guid}", Name = "GetServiceDoctorById")]
    public async Task<IActionResult> GetServiceDoctorById(Guid id)
    {
        var serviceDoctor = await _service.ServiceDoctorService.GetServiceDoctorByIdAsync(id, false);
        return Ok(serviceDoctor);
    }

    [HttpPost(Name = "CreateServiceDoctor")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateServiceDoctor([FromBody] ServiceDoctorForCreationDto serviceDoctor)
    {
        var createServiceDoctor = await _service.ServiceDoctorService.CreateServiceDoctorAsync(serviceDoctor);
        return CreatedAtRoute("GetServiceDoctorById", new { id = createServiceDoctor.Id }, createServiceDoctor);
    }

    [HttpDelete("{id:guid}", Name = "DeleteServiceDoctor")]
    public async Task<IActionResult> DeleteServiceDoctor(Guid id)
    {
        await _service.ServiceDoctorService.DeleteServiceDoctorAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateServiceDoctor")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateServiceDoctor(Guid id, [FromBody] ServiceDoctorForUpdateDto serviceDoctor)
    {
        await _service.ServiceDoctorService.UpdateServiceDoctorAsync(id, serviceDoctor, true);
        return NoContent();
    }
}