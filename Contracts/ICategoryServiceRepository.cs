using Entities.Models.Services;
using Shared.RequestFeatures;

namespace Contracts;

public interface ICategoryServiceRepository
{
    Task<PagedList<CategoryService>> GetCategoryServicesAsync(CategoryServiceParameters parameters, bool trackChanges);
    void CreateCategoryService(CategoryService categoryService);
    Task<CategoryService?> GetCategoryServiceByIdAsync(Guid id, bool trackChanges);
    void DeleteCategoryService(CategoryService categoryService);
}