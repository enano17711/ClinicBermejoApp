using Shared.CategoryService;
using Shared.ServiceDoctors;

namespace Shared.Services;

public record ServiceDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public CategoryServiceForViewDto? CategoryService { get; set; }
    public IEnumerable<ServiceDoctorDto>? ServiceDoctors { get; set; }
}