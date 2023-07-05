using Entities.Models.Sales;
using Shared.RequestFeatures;

namespace Contracts;

public interface ISaleRepository
{
    Task<PagedList<Sale>> GetSalesAsync(SaleParameters parameters, bool trackChanges);
    void CreateSale(Sale sale);
    Task<Sale?> GetSaleByIdAsync(Guid id, bool trackChanges);
    void DeleteSale(Sale sale);
}