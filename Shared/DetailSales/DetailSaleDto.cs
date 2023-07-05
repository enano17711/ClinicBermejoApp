using Shared.Items;
using Shared.Sales;
using Shared.Units;

namespace Shared.DetailSales;

public record DetailSaleDto
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
    public UnitForViewDto? Unit { get; init; }
    public SaleForViewDto? Sale { get; init; }
    public ItemForViewDto? Item { get; init; }
}