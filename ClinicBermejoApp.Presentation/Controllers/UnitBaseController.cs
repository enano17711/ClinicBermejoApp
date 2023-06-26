using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.UnitBases;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnitBaseController : ControllerBase
{
    private readonly IServiceManager _service;

    public UnitBaseController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetUnitBases")]
    public async Task<IActionResult> GetUnitBases([FromQuery] UnitBaseParameters parameters)
    {
        var pagedResult = await _service.UnitBaseService.GetUnitBasesAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.unitBases);
    }

    [HttpGet("{id:guid}", Name = "GetUnitBaseById")]
    public async Task<IActionResult> GetUnitBaseById(Guid id)
    {
        var unitBase = await _service.UnitBaseService.GetUnitBaseByIdAsync(id, false);
        return Ok(unitBase);
    }

    [HttpPost(Name = "CreateUnitBase")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateUnitBase([FromBody] UnitBaseForCreationDto unitBase)
    {
        var createUnitBase = await _service.UnitBaseService.CreateUnitBaseAsync(unitBase);
        return CreatedAtRoute("GetUnitBaseById", new { id = createUnitBase.Id }, createUnitBase);
    }

    [HttpDelete("{id:guid}", Name = "DeleteUnitBase")]
    public async Task<IActionResult> DeleteUnitBase(Guid id)
    {
        await _service.UnitBaseService.DeleteUnitBaseAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateUnitBase")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateUnitBase(Guid id, [FromBody] UnitBaseForUpdateDto unitBase)
    {
        await _service.UnitBaseService.UpdateUnitBaseAsync(id, unitBase, true);
        return NoContent();
    }

    [HttpGet("GetAllUnitBases")]
    public async Task<IActionResult> GetUnitBases()
    {
        var result = await _service.UnitBaseService.GetAllUnitBases();

        return Ok(result);
    }
}