using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Items;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IServiceManager _service;

    public ItemController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetItems")]
    public async Task<IActionResult> GetItems([FromQuery] ItemParameters parameters)
    {
        var pagedResult = await _service.ItemService.GetItemsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.items);
    }

    [HttpGet("{id:guid}", Name = "GetItemById")]
    public async Task<IActionResult> GetItemById(Guid id)
    {
        var item = await _service.ItemService.GetItemByIdAsync(id, false);
        return Ok(item);
    }

    [HttpPost(Name = "CreateItem")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateItem([FromBody] ItemForCreationDto item)
    {
        var createItem = await _service.ItemService.CreateItemAsync(item);
        return CreatedAtRoute("GetItemById", new { id = createItem.Id }, createItem);
    }

    [HttpDelete("{id:guid}", Name = "DeleteItem")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        await _service.ItemService.DeleteItemAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateItem")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateItem(Guid id, [FromBody] ItemForUpdateDto item)
    {
        await _service.ItemService.UpdateItemAsync(id, item, true);
        return NoContent();
    }
}