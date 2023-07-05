namespace Shared.Orders;

public record OrderForViewDto
{
    public Guid Id { get; init; }
    public decimal OrderTotalItemsCost { get; init; }
    public decimal OrderTotalItemsTax { get; init; }
    public decimal OrderTotalItemsDiscount { get; init; }
    public decimal OrderTax { get; init; }
    public decimal OrderDiscount { get; init; }
    public decimal OrderCost { get; init; }
    public DateTime? OrderDate { get; init; }
    public string? OrderNote { get; init; }
}