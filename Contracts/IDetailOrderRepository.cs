using Entities.Models.Orders;
using Shared.RequestFeatures;

namespace Contracts;

/// <summary>
///     Represents a repository for detail orders.
/// </summary>
public interface IDetailOrderRepository
{
    /// <summary>
    ///     Retrieves a paged list of detail orders based on the specified parameters.
    /// </summary>
    /// <param name="parameters">The parameters for filtering and pagination.</param>
    /// <param name="trackChanges">Determines whether to track changes in the entities.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the paged list of detail orders.</returns>
    Task<PagedList<DetailOrder>> GetDetailOrdersAsync(DetailOrderParameters parameters, bool trackChanges);

    /// <summary>
    ///     Creates a new detail order.
    /// </summary>
    /// <param name="detailOrder">The detail order to create.</param>
    void CreateDetailOrder(DetailOrder detailOrder);

    /// <summary>
    ///     Retrieves a detail order by its ID.
    /// </summary>
    /// <param name="id">The ID of the detail order.</param>
    /// <param name="trackChanges">Determines whether to track changes in the entity.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the detail order, or null if not
    ///     found.
    /// </returns>
    Task<DetailOrder?> GetDetailOrderByIdAsync(Guid id, bool trackChanges);

    /// <summary>
    ///     Deletes a detail order.
    /// </summary>
    /// <param name="detailOrder">The detail order to delete.</param>
    void DeleteDetailOrder(DetailOrder detailOrder);
}