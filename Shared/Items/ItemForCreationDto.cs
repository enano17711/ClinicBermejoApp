namespace Shared.Items;

public record ItemForCreationDto : ItemForManipulationDto
{
    public IEnumerable<Guid>? UnitIds { get; init; }
    public IEnumerable<Guid>? CategoryItemIds { get; init; }
}