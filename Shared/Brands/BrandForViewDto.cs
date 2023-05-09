namespace Shared.Brands;

public record BrandForViewDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}