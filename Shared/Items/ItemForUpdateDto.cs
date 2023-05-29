namespace Shared.Items;

public record ItemForUpdateDto : ItemForManipulationDto
{
    public IEnumerable<Guid>? UnitIds { get; init; }
}