using Contracts;
using Entities.Models.Sales;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class DetailSaleRepository : RepositoryBase<DetailSale>, IDetailSaleRepository
{
    public DetailSaleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    /// <summary>
    ///     Retrieves a paged list of detail sales based on the specified parameters.
    /// </summary>
    /// <param name="parameters">The parameters for filtering and pagination.</param>
    /// <param name="trackChanges">Determines whether to track changes in the entities.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the paged list of detail sales.</returns>
    public async Task<PagedList<DetailSale>> GetDetailSalesAsync(DetailSaleParameters parameters,
        bool trackChanges)
    {
        var detailSales = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(d => d.Sale)
            .Include(d => d.Item)
            .Include(d => d.Sale)
            .ToListAsync();
        return PagedList<DetailSale>.ToPagedList(detailSales,
            parameters.PageNumber,
            parameters.PageSize);
    }

    /// <summary>
    ///     Retrieves a detail sale by its ID.
    /// </summary>
    /// <param name="id">The ID of the detail sale.</param>
    /// <param name="trackChanges">Determines whether to track changes in the entity.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the detail sale, or null if not
    ///     found.
    /// </returns>
    public async Task<DetailSale?> GetDetailSaleByIdAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(d => d.Sale)
            .Include(d => d.Item)
            .Include(d => d.Sale)
            .SingleOrDefaultAsync();
    }

    /// <summary>
    ///     Creates a new detail sale.
    /// </summary>
    /// <param name="detailSale">The detail sale to create.</param>
    public void CreateDetailSale(DetailSale detailSale)
    {
        Create(detailSale);
    }

    /// <summary>
    ///     Deletes a detail sale.
    /// </summary>
    /// <param name="detailSale">The detail sale to delete.</param>
    public void DeleteDetailSale(DetailSale detailSale)
    {
        Delete(detailSale);
    }
}