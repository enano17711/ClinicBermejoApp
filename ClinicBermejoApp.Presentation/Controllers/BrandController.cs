using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Brands;
using Shared.RequestFeatures;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IServiceManager _service;

    public BrandController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetBrands")]
    public async Task<IActionResult> GetBrands([FromQuery] BrandParameters parameters)
    {
        var pagedResult = await _service.BrandService.GetBrandsAsync(parameters, false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.brands);
    }

    [HttpGet("{id:guid}", Name = "GetBrandById")]
    public async Task<IActionResult> GetBrandById(Guid id)
    {
        var brand = await _service.BrandService.GetBrandByIdAsync(id, false);
        return Ok(brand);
    }

    [HttpPost(Name = "CreateBrand")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateBrand([FromBody] BrandForCreationDto brand)
    {
        var createBrand = await _service.BrandService.CreateBrandAsync(brand);
        return CreatedAtRoute("GetBrandById", new { id = createBrand.Id }, createBrand);
    }

    [HttpDelete("{id:guid}", Name = "DeleteBrand")]
    public async Task<IActionResult> DeleteBrand(Guid id)
    {
        await _service.BrandService.DeleteBrandAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateBrand")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateBrand(Guid id, [FromBody] BrandForUpdateDto brand)
    {
        await _service.BrandService.UpdateBrandAsync(id, brand, true);
        return NoContent();
    }
}