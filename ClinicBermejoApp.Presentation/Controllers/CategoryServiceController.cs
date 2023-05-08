using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.CategoryService;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryServiceController : ControllerBase
{
    private readonly IServiceManager _service;

    public CategoryServiceController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetCategoryServices")]
    public async Task<IActionResult> GetCategoryServices([FromQuery] CategoryServiceParameters parameters)
    {
        var pagedResult = await _service.CategoryServiceService.GetCategoryServicesAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.categoryServices);
    }

    [HttpGet("{id:guid}", Name = "GetCategoryServiceById")]
    public async Task<IActionResult> GetCategoryServiceById(Guid id)
    {
        var categoryService = await _service.CategoryServiceService.GetCategoryServiceByIdAsync(id, false);
        return Ok(categoryService);
    }

    [HttpPost(Name = "CreateCategoryService")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCategoryService([FromBody] CategoryServiceForCreationDto categoryService)
    {
        var createCategoryService = await _service.CategoryServiceService.CreateCategoryServiceAsync(categoryService);
        return CreatedAtRoute("GetCategoryServiceById", new { id = createCategoryService.Id }, createCategoryService);
    }

    [HttpDelete("{id:guid}", Name = "DeleteCategoryService")]
    public async Task<IActionResult> DeleteCategoryService(Guid id)
    {
        await _service.CategoryServiceService.DeleteCategoryServiceAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateCategoryService")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateCategoryService(Guid id,
        [FromBody] CategoryServiceForUpdateDto categoryService)
    {
        await _service.CategoryServiceService.UpdateCategoryServiceAsync(id, categoryService, true);
        return NoContent();
    }
}