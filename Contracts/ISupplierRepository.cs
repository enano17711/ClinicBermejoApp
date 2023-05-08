using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface ISupplierRepository
{
    Task<PagedList<Supplier>> GetSuppliersAsync(SupplierParameters parameters, bool trackChanges);
    void CreateSupplier(Supplier supplier);
    Task<Supplier?> GetSupplierByIdAsync(Guid id, bool trackChanges);
    void DeleteSupplier(Supplier supplier);
}