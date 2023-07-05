using Shared.DetailOrders;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IDetailOrderService
{
    Task<(IEnumerable<DetailOrderDto> detailOrders, MetaData metaData)> GetDetailOrdersAsync(
        DetailOrderParameters parameters,
        bool trackChanges);

    Task<DetailOrderDto> GetDetailOrderByIdAsync(Guid id, bool trackChanges);
    Task<DetailOrderDto> CreateDetailOrderAsync(DetailOrderForCreationDto detailOrder);
    Task DeleteDetailOrderAsync(Guid id, bool trackChanges);
    Task UpdateDetailOrderAsync(Guid id, DetailOrderForUpdateDto detailOrder, bool trackChanges);
}