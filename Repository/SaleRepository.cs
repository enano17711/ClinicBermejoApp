using Contracts;
using Entities.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class SaleRepository : RepositoryBase<Sale>,
    ISaleRepository
{
    public SaleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Sale>> GetSalesAsync(SaleParameters parameters,
        bool trackChanges)
    {
        var sales = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(o => o.Customer)
            .Include(o => o.DetailSales)
            .ToListAsync();

        return PagedList<Sale>.ToPagedList(sales,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Sale?> GetSaleByIdAsync(Guid id,
        bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(m => m.Customer)
            .Include(m => m.DetailSales)
            .SingleOrDefaultAsync();
    }

    public void CreateSale(Sale sale)
    {
        Create(sale);
    }

    public void DeleteSale(Sale sale)
    {
        Delete(sale);
    }
}