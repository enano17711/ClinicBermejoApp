using Entities.Models.Items;
using Shared.RequestFeatures;

namespace Contracts;

public interface IItemRepository
{
    Task<PagedList<Item>> GetItemsAsync(ItemParameters parameters, bool trackChanges);
    void CreateItem(Item item);
    Task<Item?> GetItemByIdAsync(Guid id, bool trackChanges);
    void DeleteItem(Item item);
}