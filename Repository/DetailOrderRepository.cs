using Contracts;
using Entities.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

/// <summary>
///     Represents a repository for detail orders.
/// </summary>
public class DetailOrderRepository : RepositoryBase<DetailOrder>, IDetailOrderRepository
{
    public DetailOrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    /// <summary>
    ///     Retrieves a paged list of detail orders based on the specified parameters.
    /// </summary>
    /// <param name="parameters">The parameters for filtering and pagination.</param>
    /// <param name="trackChanges">Determines whether to track changes in the entities.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the paged list of detail orders.</returns>
    public async Task<PagedList<DetailOrder>> GetDetailOrdersAsync(DetailOrderParameters parameters,
        bool trackChanges)
    {
        var detailOrders = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(d => d.Order)
            .Include(d => d.Item)
            .Include(d => d.Order)
            .ToListAsync();
        return PagedList<DetailOrder>.ToPagedList(detailOrders,
            parameters.PageNumber,
            parameters.PageSize);
    }

    /// <summary>
    ///     Retrieves a detail order by its ID.
    /// </summary>
    /// <param name="id">The ID of the detail order.</param>
    /// <param name="trackChanges">Determines whether to track changes in the entity.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the detail order, or null if not
    ///     found.
    /// </returns>
    public async Task<DetailOrder?> GetDetailOrderByIdAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(d => d.Order)
            .Include(d => d.Item)
            .Include(d => d.Order)
            .SingleOrDefaultAsync();
    }

    /// <summary>
    ///     Creates a new detail order.
    /// </summary>
    /// <param name="detailOrder">The detail order to create.</param>
    public void CreateDetailOrder(DetailOrder detailOrder)
    {
        Create(detailOrder);
    }

    /// <summary>
    ///     Deletes a detail order.
    /// </summary>
    /// <param name="detailOrder">The detail order to delete.</param>
    public void DeleteDetailOrder(DetailOrder detailOrder)
    {
        Delete(detailOrder);
    }
}