using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Patients;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IServiceManager _service;

    public PatientController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetPatients")]
    public async Task<IActionResult> GetPatients([FromQuery] PatientParameters parameters)
    {
        var pagedResult = await _service.PatientService.GetPatientsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.patients);
    }

    [HttpGet("{id:guid}", Name = "GetPatientById")]
    public async Task<IActionResult> GetPatientById(Guid id)
    {
        var patient = await _service.PatientService.GetPatientByIdAsync(id, false);
        return Ok(patient);
    }

    [HttpPost(Name = "CreatePatient")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePatient([FromBody] PatientForCreationDto patient)
    {
        var createPatient = await _service.PatientService.CreatePatientAsync(patient);
        return CreatedAtRoute("GetPatientById", new { id = createPatient.Id }, createPatient);
    }

    [HttpDelete("{id:guid}", Name = "DeletePatient")]
    public async Task<IActionResult> DeletePatient(Guid id)
    {
        await _service.PatientService.DeletePatientAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdatePatient")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientForUpdateDto patient)
    {
        await _service.PatientService.UpdatePatientAsync(id, patient, true);
        return NoContent();
    }
}