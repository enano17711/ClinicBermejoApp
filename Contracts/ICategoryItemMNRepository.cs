using Entities.Models.Items;

namespace Contracts;

public interface ICategoryItemMNRepository
{
    Task<CategoryItemMN?> GetCategoryItemMNByIdAsync(Guid itemId, Guid categoryItemId, bool trackChanges);
    void CreateCategoryItemMN(CategoryItemMN categoryItemMn);

    void DeleteCategoryItemMN(CategoryItemMN categoryItemMn);
}