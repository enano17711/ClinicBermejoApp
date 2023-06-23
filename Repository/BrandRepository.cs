using Contracts;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class BrandRepository : RepositoryBase<Brand>,
    IBrandRepository
{
    public BrandRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<List<Brand>> GetAllBrandsAsync()
    {
        var brands = await FindAll(false).ToListAsync();
        return brands;
    }

    public async Task<PagedList<Brand>> GetBrandsAsync(BrandParameters parameters,
        bool trackChanges)
    {
        var brands = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(b => b.Items)
            .ToListAsync();

        return PagedList<Brand>.ToPagedList(brands,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Brand?> GetBrandByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(b => b.Items)
            .SingleOrDefaultAsync();

    public void CreateBrand(Brand brand) =>
        Create(brand);

    public void DeleteBrand(Brand brand) =>
        Delete(brand);
}