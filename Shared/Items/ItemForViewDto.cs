namespace Shared.Items;

public record ItemForViewDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Code { get; init; }
    public decimal? StockItem { get; set; }
    public string? Allotment { get; set; }
    public DateTime? Expiration { get; set; }
    public string? Description { get; init; }
}