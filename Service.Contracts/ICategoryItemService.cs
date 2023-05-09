using Shared.CategoryItem;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ICategoryItemService
{
    Task<(IEnumerable<CategoryItemDto> categoryItems, MetaData metaData)> GetCategoryItemsAsync(
        CategoryItemParameters parameters,
        bool trackChanges);

    Task<CategoryItemDto> GetCategoryItemByIdAsync(Guid id, bool trackChanges);
    Task<CategoryItemDto> CreateCategoryItemAsync(CategoryItemForCreationDto categoryItem);
    Task DeleteCategoryItemAsync(Guid id, bool trackChanges);
    Task UpdateCategoryItemAsync(Guid id, CategoryItemForUpdateDto categoryItem, bool trackChanges);
}