using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Appointments;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IServiceManager _service;

    public AppointmentController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetAppointments")]
    public async Task<IActionResult> GetAppointments([FromQuery] AppointmentParameters parameters)
    {
        var pagedResult = await _service.AppointmentService.GetAppointmentsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.appointments);
    }

    [HttpGet("{id:guid}", Name = "GetAppointmentById")]
    public async Task<IActionResult> GetAppointmentById(Guid id)
    {
        var appointment = await _service.AppointmentService.GetAppointmentByIdAsync(id, false);
        return Ok(appointment);
    }

    [HttpPost(Name = "CreateAppointment")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateAppointment([FromBody] AppointmentForCreationDto appointment)
    {
        var createAppointment = await _service.AppointmentService.CreateAppointmentAsync(appointment);
        return CreatedAtRoute("GetAppointmentById", new { id = createAppointment.Id }, createAppointment);
    }

    [HttpDelete("{id:guid}", Name = "DeleteAppointment")]
    public async Task<IActionResult> DeleteAppointment(Guid id)
    {
        await _service.AppointmentService.DeleteAppointmentAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateAppointment")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] AppointmentForUpdateDto appointment)
    {
        await _service.AppointmentService.UpdateAppointmentAsync(id, appointment, true);
        return NoContent();
    }
}