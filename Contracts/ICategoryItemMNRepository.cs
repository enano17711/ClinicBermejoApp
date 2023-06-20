using Entities.Models.Items;

namespace Contracts;

public interface ICategoryItemMNRepository
{
    void CreateCategoryItemMN(CategoryItemMN categoryItemMn);

    void DeleteCategoryItemMN(CategoryItemMN categoryItemMn);
}