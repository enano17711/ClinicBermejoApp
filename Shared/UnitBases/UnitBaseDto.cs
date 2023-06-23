using Shared.Units;

namespace Shared.UnitBases;

public record UnitBaseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string ShortName { get; init; } = string.Empty;
    public IEnumerable<UnitDto>? Units { get; init; }
}