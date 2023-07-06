using Shared.Orders;
using Shared.Sales;

namespace Shared.Notes;

public record NoteDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public AdjustmentType Type { get; set; }
    public ICollection<OrderForViewDto>? Orders { get; set; }
    public ICollection<SaleForViewDto>? Sales { get; set; }
}