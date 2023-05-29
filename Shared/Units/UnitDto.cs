using Shared.DetailMovements;
using Shared.Items;

namespace Shared.Units;

public record UnitDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IEnumerable<ItemForViewDto>? Items { get; set; }
}