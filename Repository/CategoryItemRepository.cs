using Contracts;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class CategoryItemRepository : RepositoryBase<CategoryItem>,
    ICategoryItemRepository
{
    public CategoryItemRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<CategoryItem>> GetCategoryItemsAsync(CategoryItemParameters parameters,
        bool trackChanges)
    {
        var categoryItems = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(ci => ci.Items)
            .ToListAsync();

        return PagedList<CategoryItem>.ToPagedList(categoryItems,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<CategoryItem?> GetCategoryItemByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(ci => ci.Items)
            .SingleOrDefaultAsync();

    public void CreateCategoryItem(CategoryItem categoryItem) =>
        Create(categoryItem);

    public void DeleteCategoryItem(CategoryItem categoryItem) =>
        Delete(categoryItem);
}