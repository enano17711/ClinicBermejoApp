using Shared.CategoryService;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ICategoryServiceService
{
    Task<(IEnumerable<CategoryServiceDto> categoryServices, MetaData metaData)> GetCategoryServicesAsync(
        CategoryServiceParameters parameters,
        bool trackChanges);

    Task<CategoryServiceDto> GetCategoryServiceByIdAsync(Guid id, bool trackChanges);
    Task<CategoryServiceDto> CreateCategoryServiceAsync(CategoryServiceForCreationDto categoryService);
    Task DeleteCategoryServiceAsync(Guid id, bool trackChanges);
    Task UpdateCategoryServiceAsync(Guid id, CategoryServiceForUpdateDto categoryService, bool trackChanges);
}