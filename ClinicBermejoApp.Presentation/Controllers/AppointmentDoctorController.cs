using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.AppointmentDoctors;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentDoctorController : ControllerBase
{
    private readonly IServiceManager _service;

    public AppointmentDoctorController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetAppointmentDoctors")]
    public async Task<IActionResult> GetAppointmentDoctors([FromQuery] AppointmentDoctorParameters parameters)
    {
        var pagedResult = await _service.AppointmentDoctorService.GetAppointmentDoctorsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.appointmentDoctors);
    }

    [HttpGet("{id:guid}", Name = "GetAppointmentDoctorById")]
    public async Task<IActionResult> GetAppointmentDoctorById(Guid id)
    {
        var appointmentDoctor = await _service.AppointmentDoctorService.GetAppointmentDoctorByIdAsync(id, false);
        return Ok(appointmentDoctor);
    }

    [HttpPost(Name = "CreateAppointmentDoctor")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAppointmentDoctor(
        [FromBody] AppointmentDoctorForCreationDto appointmentDoctor)
    {
        var createAppointmentDoctor =
            await _service.AppointmentDoctorService.CreateAppointmentDoctorAsync(appointmentDoctor);
        return CreatedAtRoute("GetAppointmentDoctorById", new { id = createAppointmentDoctor.Id },
            createAppointmentDoctor);
    }

    [HttpDelete("{id:guid}", Name = "DeleteAppointmentDoctor")]
    public async Task<IActionResult> DeleteAppointmentDoctor(Guid id)
    {
        await _service.AppointmentDoctorService.DeleteAppointmentDoctorAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateAppointmentDoctor")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateAppointmentDoctor(Guid id,
        [FromBody] AppointmentDoctorForUpdateDto appointmentDoctor)
    {
        await _service.AppointmentDoctorService.UpdateAppointmentDoctorAsync(id, appointmentDoctor, true);
        return NoContent();
    }
}