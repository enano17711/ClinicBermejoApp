using Shared.Services;

namespace Shared.CategoryService;

public record CategoryServiceDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public IEnumerable<ServiceForViewDto>? Services { get; set; }
}