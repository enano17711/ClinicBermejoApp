namespace Shared.CategoryItem;

public record CategoryItemForViewDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}