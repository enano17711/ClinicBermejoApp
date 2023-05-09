using Shared.Items;

namespace Shared.Brands;

public record BrandDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IEnumerable<ItemForViewDto>? Items { get; set; }
}