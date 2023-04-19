using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared;
using Shared.Doctors;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IServiceManager _service;

    public DoctorController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetDoctors")]
    public async Task<IActionResult> GetDoctors([FromQuery] DoctorParameters parameters)
    {
        var pagedResult = await _service.DoctorService.GetDoctorsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.doctors);
    }

    [HttpGet("{id:guid}", Name = "GetDoctorById")]
    public async Task<IActionResult> GetDoctorById(Guid id)
    {
        var doctor = await _service.DoctorService.GetDoctorByIdAsync(id, false);
        return Ok(doctor);
    }

    [HttpPost(Name = "CreateDoctor")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateDoctor([FromBody] DoctorForCreationDto doctor)
    {
        var createDoctor = await _service.DoctorService.CreateDoctorAsync(doctor);
        return CreatedAtRoute("GetDoctorById", new { id = createDoctor.Id }, createDoctor);
    }

    [HttpDelete("{id:guid}", Name = "DeleteDoctor")]
    public async Task<IActionResult> DeleteDoctor(Guid id)
    {
        await _service.DoctorService.DeleteDoctorAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateDoctor")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateDoctor(Guid id, [FromBody] DoctorForUpdateDto doctor)
    {
        await _service.DoctorService.UpdateDoctorAsync(id, doctor, true);
        return NoContent();
    }
}