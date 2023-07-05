using Entities.Models.Orders;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDetailOrderRepository
{
    Task<PagedList<DetailOrder>> GetDetailOrdersAsync(DetailOrderParameters parameters, bool trackChanges);
    void CreateDetailOrder(DetailOrder detailOrder);
    Task<DetailOrder?> GetDetailOrderByIdAsync(Guid id, bool trackChanges);
    void DeleteDetailOrder(DetailOrder detailOrder);
}