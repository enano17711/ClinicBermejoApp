using Contracts;
using Entities.Models.Items;

namespace Repository;

public class CategoryItemMNRepository : RepositoryBase<CategoryItemMN>, ICategoryItemMNRepository
{
    public CategoryItemMNRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateCategoryItemMN(CategoryItemMN categoryItemMn)
    {
        Create(categoryItemMn);
    }

    public void DeleteCategoryItemMN(CategoryItemMN categoryItemMn)
    {
        Delete(categoryItemMn);
    }
}