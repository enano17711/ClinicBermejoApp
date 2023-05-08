using Shared.RequestFeatures;
using Shared.Suppliers;

namespace Service.Contracts;

public interface ISupplierService
{
    Task<(IEnumerable<SupplierDto> suppliers, MetaData metaData)> GetSuppliersAsync(SupplierParameters parameters,
        bool trackChanges);

    Task<SupplierDto> GetSupplierByIdAsync(Guid id, bool trackChanges);
    Task<SupplierDto> CreateSupplierAsync(SupplierForCreationDto supplier);
    Task DeleteSupplierAsync(Guid id, bool trackChanges);
    Task UpdateSupplierAsync(Guid id, SupplierForUpdateDto supplier, bool trackChanges);
}