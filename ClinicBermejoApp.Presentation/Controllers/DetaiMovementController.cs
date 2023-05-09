using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DetailMovements;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DetailMovementController : ControllerBase
{
    private readonly IServiceManager _service;

    public DetailMovementController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetDetailMovements")]
    public async Task<IActionResult> GetDetailMovements([FromQuery] DetailMovementParameters parameters)
    {
        var pagedResult = await _service.DetailMovementService.GetDetailMovementsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.detailMovements);
    }

    [HttpGet("{id:guid}", Name = "GetDetailMovementById")]
    public async Task<IActionResult> GetDetailMovementById(Guid id)
    {
        var detailMovement = await _service.DetailMovementService.GetDetailMovementByIdAsync(id, false);
        return Ok(detailMovement);
    }

    [HttpPost(Name = "CreateDetailMovement")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateDetailMovement([FromBody] DetailMovementForCreationDto detailMovement)
    {
        var createDetailMovement = await _service.DetailMovementService.CreateDetailMovementAsync(detailMovement);
        return CreatedAtRoute("GetDetailMovementById", new { id = createDetailMovement.Id }, createDetailMovement);
    }

    [HttpDelete("{id:guid}", Name = "DeleteDetailMovement")]
    public async Task<IActionResult> DeleteDetailMovement(Guid id)
    {
        await _service.DetailMovementService.DeleteDetailMovementAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateDetailMovement")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateDetailMovement(Guid id, [FromBody] DetailMovementForUpdateDto detailMovement)
    {
        await _service.DetailMovementService.UpdateDetailMovementAsync(id, detailMovement, true);
        return NoContent();
    }
}