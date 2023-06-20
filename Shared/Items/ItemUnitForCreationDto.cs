using Shared.Units;

namespace Shared.Items;

public record ItemUnitForCreationDto : ItemForManipulationDto
{
    public ICollection<UnitForCreationDto>? Units { get; init; }
}