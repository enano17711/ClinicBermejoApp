namespace Shared.Items;

public record ItemUnitForCreationDto
{
    public Guid ItemId { get; set; }
    public Guid UnitId { get; set; }
}