namespace Shared.Items;

public record ItemForViewDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}