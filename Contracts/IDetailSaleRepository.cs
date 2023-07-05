using Entities.Models.Sales;
using Shared.RequestFeatures;

namespace Contracts;

public interface IDetailSaleRepository
{
    /// <summary>
    ///     Retrieves a paged list of detail sales based on the specified parameters.
    /// </summary>
    /// <param name="parameters">The parameters for filtering and pagination.</param>
    /// <param name="trackChanges">Determines whether to track changes in the entities.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the paged list of detail sales.</returns>
    Task<PagedList<DetailSale>> GetDetailSalesAsync(DetailSaleParameters parameters, bool trackChanges);

    /// <summary>
    ///     Creates a new detail sale.
    /// </summary>
    /// <param name="detailSale">The detail sale to create.</param>
    void CreateDetailSale(DetailSale detailSale);

    /// <summary>
    ///     Retrieves a detail sale by its ID.
    /// </summary>
    /// <param name="id">The ID of the detail sale.</param>
    /// <param name="trackChanges">Determines whether to track changes in the entity.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the detail sale, or null if not
    ///     found.
    /// </returns>
    Task<DetailSale?> GetDetailSaleByIdAsync(Guid id, bool trackChanges);

    /// <summary>
    ///     Deletes a detail sale.
    /// </summary>
    /// <param name="detailSale">The detail sale to delete.</param>
    void DeleteDetailSale(DetailSale detailSale);
}