using Shared.Sales;

namespace Shared.Customers;

public record CustomerDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Ci { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? Date { get; set; }
    public string? Address { get; set; }
    public string? Nit { get; set; }
    public IEnumerable<SaleForViewDto>? Sales { get; set; }
}