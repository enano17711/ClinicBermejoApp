using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.CategoryItem;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryItemController : ControllerBase
{
    private readonly IServiceManager _service;

    public CategoryItemController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetCategoryItems")]
    public async Task<IActionResult> GetCategoryItems([FromQuery] CategoryItemParameters parameters)
    {
        var pagedResult = await _service.CategoryItemService.GetCategoryItemsAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.categoryItems);
    }

    [HttpGet("{id:guid}", Name = "GetCategoryItemById")]
    public async Task<IActionResult> GetCategoryItemById(Guid id)
    {
        var categoryItem = await _service.CategoryItemService.GetCategoryItemByIdAsync(id, false);
        return Ok(categoryItem);
    }

    [HttpPost(Name = "CreateCategoryItem")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCategoryItem([FromBody] CategoryItemForCreationDto categoryItem)
    {
        var createCategoryItem = await _service.CategoryItemService.CreateCategoryItemAsync(categoryItem);
        return CreatedAtRoute("GetCategoryItemById", new { id = createCategoryItem.Id }, createCategoryItem);
    }

    [HttpDelete("{id:guid}", Name = "DeleteCategoryItem")]
    public async Task<IActionResult> DeleteCategoryItem(Guid id)
    {
        await _service.CategoryItemService.DeleteCategoryItemAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateCategoryItem")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCategoryItem(Guid id, [FromBody] CategoryItemForUpdateDto categoryItem)
    {
        await _service.CategoryItemService.UpdateCategoryItemAsync(id, categoryItem, true);
        return NoContent();
    }
}