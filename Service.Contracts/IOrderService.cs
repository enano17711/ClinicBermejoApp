using Shared.Orders;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IOrderService
{
    Task<(IEnumerable<OrderDto> orders, MetaData metaData)> GetOrdersAsync(OrderParameters parameters,
        bool trackChanges);

    Task<OrderDto> GetOrderByIdAsync(Guid id, bool trackChanges);
    Task<OrderDto> CreateOrderAsync(OrderForCreationDto order);
    Task DeleteOrderAsync(Guid id, bool trackChanges);
    Task UpdateOrderAsync(Guid id, OrderForUpdateDto order, bool trackChanges);
}