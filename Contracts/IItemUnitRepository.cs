using Entities.Models;
using Entities.Models.Items;
using Entities.Models.Staff;
using Shared.RequestFeatures;

namespace Contracts;

public interface IItemUnitRepository
{
    Task<PagedList<ItemUnit>> GetItemUnitsAsync(ItemUnitParameters parameters, bool trackChanges);
    void CreateItemUnit(ItemUnit itemUnit);
    Task<ItemUnit?> GetItemUnitByIdAsync(Guid itemId, Guid unitId, bool trackChanges);
    void DeleteItemUnit(ItemUnit itemUnit);
}