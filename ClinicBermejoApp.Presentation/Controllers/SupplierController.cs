using System.Text.Json;
using ClinicBermejoApp.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.Suppliers;

namespace ClinicBermejoApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly IServiceManager _service;

    public SupplierController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetSuppliers")]
    public async Task<IActionResult> GetSuppliers([FromQuery] SupplierParameters parameters)
    {
        var pagedResult = await _service.SupplierService.GetSuppliersAsync(parameters, false);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        return Ok(pagedResult.suppliers);
    }

    [HttpGet("{id:guid}", Name = "GetSupplierById")]
    public async Task<IActionResult> GetSupplierById(Guid id)
    {
        var supplier = await _service.SupplierService.GetSupplierByIdAsync(id, false);
        return Ok(supplier);
    }

    [HttpPost(Name = "CreateSupplier")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateSupplier([FromBody] SupplierForCreationDto supplier)
    {
        var createSupplier = await _service.SupplierService.CreateSupplierAsync(supplier);
        return CreatedAtRoute("GetSupplierById", new { id = createSupplier.Id }, createSupplier);
    }

    [HttpDelete("{id:guid}", Name = "DeleteSupplier")]
    public async Task<IActionResult> DeleteSupplier(Guid id)
    {
        await _service.SupplierService.DeleteSupplierAsync(id, false);
        return NoContent();
    }

    [HttpPut("{id:guid}", Name = "UpdateSupplier")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateSupplier(Guid id, [FromBody] SupplierForUpdateDto supplier)
    {
        await _service.SupplierService.UpdateSupplierAsync(id, supplier, true);
        return NoContent();
    }
}