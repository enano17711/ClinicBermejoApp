namespace Shared.Items;

public record ItemForViewDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }
}