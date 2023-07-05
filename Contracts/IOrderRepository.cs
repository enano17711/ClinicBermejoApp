using Entities.Models.Orders;
using Shared.RequestFeatures;

namespace Contracts;

public interface IOrderRepository
{
    Task<PagedList<Order>> GetOrdersAsync(OrderParameters parameters, bool trackChanges);
    void CreateOrder(Order order);
    Task<Order?> GetOrderByIdAsync(Guid id, bool trackChanges);
    void DeleteOrder(Order order);
}