using Shared.DetailOrders;
using Shared.Notes;
using Shared.Suppliers;

namespace Shared.Orders;

public record OrderDto
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
    public SupplierForViewDto? Supplier { get; init; }
    public NoteForViewDto? Note { get; init; }
    public ICollection<DetailOrderForViewDto>? DetailOrders { get; init; }
}