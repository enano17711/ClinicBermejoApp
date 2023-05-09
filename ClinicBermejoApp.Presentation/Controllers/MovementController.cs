using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Movements;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovementController : ControllerBase
{
    private readonly IServiceManager _service;

    public MovementController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetMovements")]
    public async Task<IActionResult> GetMovements([FromQuery] MovementParameters parameters)
    {
        var pagedResult = await _service.MovementService.GetMovementsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.movements);
    }

    [HttpGet("{id:guid}", Name = "GetMovementById")]
    public async Task<IActionResult> GetMovementById(Guid id)
    {
        var movement = await _service.MovementService.GetMovementByIdAsync(id, false);
        return Ok(movement);
    }

    [HttpPost(Name = "CreateMovement")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateMovement([FromBody] MovementForCreationDto movement)
    {
        var createMovement = await _service.MovementService.CreateMovementAsync(movement);
        return CreatedAtRoute("GetMovementById", new { id = createMovement.Id }, createMovement);
    }

    [HttpDelete("{id:guid}", Name = "DeleteMovement")]
    public async Task<IActionResult> DeleteMovement(Guid id)
    {
        await _service.MovementService.DeleteMovementAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateMovement")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateMovement(Guid id, [FromBody] MovementForUpdateDto movement)
    {
        await _service.MovementService.UpdateMovementAsync(id, movement, true);
        return NoContent();
    }
}