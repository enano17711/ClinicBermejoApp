using Shared.Items;
using Shared.UnitBases;

namespace Shared.Units;

public record UnitDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ShortName { get; set; }

    public uint Value { get; set; }

    public string? Operation { get; set; }

    public IEnumerable<ItemForViewDto>? Items { get; set; }

    public UnitBaseForViewDto? UnitBase { get; set; }
}