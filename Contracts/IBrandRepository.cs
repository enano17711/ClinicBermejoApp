using Entities.Models.Items;
using Shared.RequestFeatures;

namespace Contracts;

public interface IBrandRepository
{
    Task<List<Brand>> GetAllBrandsAsync();
    Task<PagedList<Brand>> GetBrandsAsync(BrandParameters parameters, bool trackChanges);
    void CreateBrand(Brand brand);
    Task<Brand?> GetBrandByIdAsync(Guid id, bool trackChanges);
    void DeleteBrand(Brand brand);
}