using Entities.Models.Items;
using Shared.RequestFeatures;

namespace Contracts;

public interface IItemRepository
{
    Task<PagedList<Item>> GetItemsAsync(ItemParameters parameters, bool trackChanges);
    Task<Item?> GetItemByIdAsync(Guid id, bool trackChanges);
    Task<Item?> GetItemByAllotmentAsync(Guid id, string allotment, bool trackChanges);
    void CreateItem(Item item);
    void DeleteItem(Item item);
}