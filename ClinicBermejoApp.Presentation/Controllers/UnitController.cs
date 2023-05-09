using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.Units;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnitController : ControllerBase
{
    private readonly IServiceManager _service;

    public UnitController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetUnits")]
    public async Task<IActionResult> GetUnits([FromQuery] UnitParameters parameters)
    {
        var pagedResult = await _service.UnitService.GetUnitsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.units);
    }

    [HttpGet("{id:guid}", Name = "GetUnitById")]
    public async Task<IActionResult> GetUnitById(Guid id)
    {
        var unit = await _service.UnitService.GetUnitByIdAsync(id, false);
        return Ok(unit);
    }

    [HttpPost(Name = "CreateUnit")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateUnit([FromBody] UnitForCreationDto unit)
    {
        var createUnit = await _service.UnitService.CreateUnitAsync(unit);
        return CreatedAtRoute("GetUnitById", new { id = createUnit.Id }, createUnit);
    }

    [HttpDelete("{id:guid}", Name = "DeleteUnit")]
    public async Task<IActionResult> DeleteUnit(Guid id)
    {
        await _service.UnitService.DeleteUnitAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateUnit")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateUnit(Guid id, [FromBody] UnitForUpdateDto unit)
    {
        await _service.UnitService.UpdateUnitAsync(id, unit, true);
        return NoContent();
    }
}