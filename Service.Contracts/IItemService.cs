using Shared.Items;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IItemService
{
    Task<(IEnumerable<ItemDto> items, MetaData metaData)> GetItemsAsync(ItemParameters parameters,
        bool trackChanges);

    Task<ItemDto> GetItemByIdAsync(Guid id, bool trackChanges);
    Task<ItemDto> CreateItemAsync(ItemForCreationDto item);
    Task DeleteItemAsync(Guid id, bool trackChanges);
    Task UpdateItemAsync(Guid id, ItemForUpdateDto item, bool trackChanges);
    Task CreateItemUnitAsync(ItemUnitForCreationDto itemUnit);
    Task DeleteItemUnitAsync(ItemUnitForCreationDto itemUnit);
}