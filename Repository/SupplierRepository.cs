using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class SupplierRepository : RepositoryBase<Supplier>,
    ISupplierRepository
{
    public SupplierRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Supplier>> GetSuppliersAsync(SupplierParameters parameters,
        bool trackChanges)
    {
        var suppliers = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(s => s.Orders)
            .ToListAsync();

        return PagedList<Supplier>.ToPagedList(suppliers,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Supplier?> GetSupplierByIdAsync(Guid id,
        bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(s => s.Orders)
            .SingleOrDefaultAsync();
    }

    public void CreateSupplier(Supplier supplier)
    {
        Create(supplier);
    }

    public void DeleteSupplier(Supplier supplier)
    {
        Delete(supplier);
    }
}