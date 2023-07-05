using Shared.Items;
using Shared.Orders;
using Shared.Units;

namespace Shared.DetailOrders;

public record DetailOrderDto
{
    public Guid Id { get; init; }
    public decimal DetailOrderItemCost { get; init; }
    public decimal DetailOrderItemTax { get; init; }
    public decimal DetailOrderItemDiscount { get; init; }
    public decimal DetailOrderItemTotal { get; init; }
    public uint DetailOrderItemQuantity { get; init; }
    public uint DetailOrderItemSingleUnits { get; init; }
    public DateTime DetailOrderItemDate { get; init; }
    public string? DetailItemAllotment { get; init; }
    public DateTime DetailOrderItemExpiration { get; init; }
    public UnitForViewDto? Unit { get; init; }
    public OrderForViewDto? Order { get; init; }
    public ItemForViewDto? Item { get; init; }
}