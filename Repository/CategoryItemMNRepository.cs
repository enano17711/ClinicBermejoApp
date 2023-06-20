using Contracts;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CategoryItemMNRepository : RepositoryBase<CategoryItemMN>, ICategoryItemMNRepository
{
    public CategoryItemMNRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<CategoryItemMN?>
        GetCategoryItemMNByIdAsync(Guid itemId, Guid categoryItemId, bool trackChanges) =>
        await FindByCondition(ciMN => ciMN.ItemId == itemId && ciMN.CategoryItemId == categoryItemId, trackChanges)
            .Include(ciMN => ciMN.CategoryItem)
            .Include(ciMN => ciMN.Item)
            .SingleOrDefaultAsync();

    public void CreateCategoryItemMN(CategoryItemMN categoryItemMn)
    {
        Create(categoryItemMn);
    }

    public void DeleteCategoryItemMN(CategoryItemMN categoryItemMn)
    {
        Delete(categoryItemMn);
    }
}