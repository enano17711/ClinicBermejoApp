namespace Shared.UnitBases;

public record UnitBaseForViewDto
{
    public Guid Id { get; init; }

    public string? ShortName { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }
}