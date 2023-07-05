using Shared.DetailOrders;

namespace Shared.Orders;

public record OrderForUpdateDto : OrderForManipulationDto
{
    public IEnumerable<DetailOrderForCreationDto>? DetailOrders { get; init; }
}