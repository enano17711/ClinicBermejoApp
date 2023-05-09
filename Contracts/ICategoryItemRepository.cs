using Entities.Models.Items;
using Shared.RequestFeatures;

namespace Contracts;

public interface ICategoryItemRepository
{
    Task<PagedList<CategoryItem>> GetCategoryItemsAsync(CategoryItemParameters parameters, bool trackChanges);
    void CreateCategoryItem(CategoryItem categoryItem);
    Task<CategoryItem?> GetCategoryItemByIdAsync(Guid id, bool trackChanges);
    void DeleteCategoryItem(CategoryItem categoryItem);
}