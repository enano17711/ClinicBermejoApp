using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Nurses;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NurseController : ControllerBase
{
    private readonly IServiceManager _service;

    public NurseController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetNurses")]
    public async Task<IActionResult> GetNurses([FromQuery] NurseParameters parameters)
    {
        var pagedResult = await _service.NurseService.GetNursesAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.nurses);
    }

    [HttpGet("{id:guid}", Name = "GetNurseById")]
    public async Task<IActionResult> GetNurseById(Guid id)
    {
        var nurse = await _service.NurseService.GetNurseByIdAsync(id, false);
        return Ok(nurse);
    }

    [HttpPost(Name = "CreateNurse")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateNurse([FromBody] NurseForCreationDto nurse)
    {
        var createNurse = await _service.NurseService.CreateNurseAsync(nurse);
        return CreatedAtRoute("GetNurseById", new { id = createNurse.Id }, createNurse);
    }

    [HttpDelete("{id:guid}", Name = "DeleteNurse")]
    public async Task<IActionResult> DeleteNurse(Guid id)
    {
        await _service.NurseService.DeleteNurseAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateNurse")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateNurse(Guid id, [FromBody] NurseForUpdateDto nurse)
    {
        await _service.NurseService.UpdateNurseAsync(id, nurse, true);
        return NoContent();
    }
}