using Shared.DetailOrders;
using Shared.Suppliers;

namespace Shared.Orders;

public record OrderDto
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public decimal Amount { get; set; }
    public decimal Quantity { get; set; }
    public DateTime? Date { get; set; }
    public SupplierForViewDto? Supplier { get; set; }
    public ICollection<DetailOrderForViewDto>? DetailOrders { get; set; }
}