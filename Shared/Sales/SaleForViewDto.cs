namespace Shared.Sales;

public record SaleForViewDto
{
    public Guid Id { get; init; }
    public decimal SaleTotalItemsCost { get; init; }
    public decimal SaleTotalItemsTax { get; init; }
    public decimal SaleTotalItemsDiscount { get; init; }
    public decimal SaleTax { get; init; }
    public decimal SaleDiscount { get; init; }
    public decimal SaleCost { get; init; }
    public DateTime? SaleDate { get; init; }
    public string? SaleNote { get; init; }
}