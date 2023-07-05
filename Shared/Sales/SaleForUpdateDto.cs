using Shared.DetailSales;

namespace Shared.Sales;

public record SaleForUpdateDto : SaleForManipulationDto
{
    public IEnumerable<DetailSaleForCreationDto>? DetailSales { get; init; }
}