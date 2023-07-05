using Shared.DetailSales;

namespace Shared.Sales;

public record SaleForCreationDto : SaleForManipulationDto
{
    public IEnumerable<DetailSaleForCreationDto>? DetailSales { get; init; }
}