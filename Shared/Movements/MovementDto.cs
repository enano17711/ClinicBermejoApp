using Shared.DetailMovements;
using Shared.Suppliers;

namespace Shared.Movements;

public record MovementDto
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public decimal Amount { get; set; }
    public decimal Quantity { get; set; }
    public DateTime? Date { get; set; }
    public SupplierForViewDto? Supplier { get; set; }
    public ICollection<DetailMovementForViewDto>? DetailMovements { get; set; }
}