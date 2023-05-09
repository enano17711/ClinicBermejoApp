namespace Shared.DetailMovements;

public record DetailMovementForViewDto
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public decimal Quantity { get; set; }

    public DateTime Date { get; set; }

    public string? Allotment { get; set; }

    public char IsAllotment { get; set; }
}