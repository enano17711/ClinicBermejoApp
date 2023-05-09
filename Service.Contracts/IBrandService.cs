using Shared.Brands;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IBrandService
{
    Task<(IEnumerable<BrandDto> brands, MetaData metaData)> GetBrandsAsync(BrandParameters parameters,
        bool trackChanges);

    Task<BrandDto> GetBrandByIdAsync(Guid id, bool trackChanges);
    Task<BrandDto> CreateBrandAsync(BrandForCreationDto brand);
    Task DeleteBrandAsync(Guid id, bool trackChanges);
    Task UpdateBrandAsync(Guid id, BrandForUpdateDto brand, bool trackChanges);
}