using Shared.Items;

namespace Shared.CategoryItem;

public record CategoryItemDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IEnumerable<ItemForViewDto>? Items { get; set; }
}