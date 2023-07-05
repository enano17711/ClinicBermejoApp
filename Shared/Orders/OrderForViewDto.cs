namespace Shared.Orders;

public record OrderForViewDto
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public decimal Amount { get; set; }
    public decimal Quantity { get; set; }
    public DateTime? Date { get; set; }
}