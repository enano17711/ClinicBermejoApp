namespace Shared.DetailSales;

public record DetailSaleForViewDto
{
    public Guid Id { get; init; }
    public decimal DetailSaleItemCost { get; init; }
    public decimal DetailSaleItemTax { get; init; }
    public decimal DetailSaleItemDiscount { get; init; }
    public decimal DetailSaleItemTotal { get; init; }
    public uint DetailSaleItemQuantity { get; init; }
    public uint DetailSaleItemSingleUnits { get; init; }
    public DateTime DetailSaleItemDate { get; init; }
    public string? DetailItemAllotment { get; init; }
    public DateTime DetailSaleItemExpiration { get; init; }
}