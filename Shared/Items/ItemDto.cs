using Shared.Brands;
using Shared.CategoryItem;
using Shared.DetailMovements;
using Shared.Units;

namespace Shared.Items;

public record ItemDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public CategoryItemForViewDto? CategoryItem { get; set; }

    public BrandForViewDto? Brand { get; set; }

    public UnitForViewDto? Unit { get; set; }

    public ICollection<DetailMovementForViewDto>? DetailMovements { get; set; }
}