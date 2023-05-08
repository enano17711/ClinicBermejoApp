using Contracts;
using Entities.Models.Services;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class CategoryServiceRepository : RepositoryBase<CategoryService>,
    ICategoryServiceRepository
{
    public CategoryServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<CategoryService>> GetCategoryServicesAsync(CategoryServiceParameters parameters,
        bool trackChanges)
    {
        var categoryServices = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .ToListAsync();

        return PagedList<CategoryService>.ToPagedList(categoryServices,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<CategoryService?> GetCategoryServiceByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .SingleOrDefaultAsync();

    public void CreateCategoryService(CategoryService categoryService) =>
        Create(categoryService);

    public void DeleteCategoryService(CategoryService categoryService) =>
        Delete(categoryService);
}