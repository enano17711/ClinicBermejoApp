namespace Shared.Units;

public record UnitForViewDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}