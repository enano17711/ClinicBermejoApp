using Shared.Brands;
using Shared.CategoryItem;
using Shared.Units;

namespace Shared.Items;

public record ItemDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Code { get; init; }
    public string? Description { get; init; }
    public decimal? StockItem { get; set; }
    public string? Allotment { get; set; }
    public DateTime? Expiration { get; set; }
    public ICollection<CategoryItemForViewDto>? CategoryItems { get; init; }
    public ICollection<UnitForViewDto>? Units { get; init; }
    public BrandForViewDto? Brand { get; init; }
}