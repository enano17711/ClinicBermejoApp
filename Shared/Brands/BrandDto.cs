using Shared.Items;

namespace Shared.Brands;

public record BrandDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public IEnumerable<ItemForViewDto>? Items { get; init; }
}