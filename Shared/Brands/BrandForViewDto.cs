namespace Shared.Brands;

public record BrandForViewDto
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }
}