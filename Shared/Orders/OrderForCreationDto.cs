using Shared.DetailOrders;

namespace Shared.Orders;

public record OrderForCreationDto : OrderForManipulationDto
{
    public IEnumerable<DetailOrderForCreationDto>? DetailOrders { get; init; }
}