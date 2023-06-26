using Contracts;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class UnitBaseRepository : RepositoryBase<UnitBase>, IUnitBaseRepository
{
    public UnitBaseRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<PagedList<UnitBase>> GetUnitBasesAsync(UnitBaseParameters unitBaseParameters,
        bool trackChanges)
    {
        var unitBases = await FindAll(trackChanges)
            .SearchGeneric(unitBaseParameters.SearchColumn, unitBaseParameters.SearchTerm)
            .SortGeneric(unitBaseParameters.SortColumn, unitBaseParameters.SortOrder)
            .Include(u => u.Units)
            .OrderBy(u => u.Name)
            .ToListAsync();

        return PagedList<UnitBase>.ToPagedList(unitBases, unitBaseParameters.PageNumber,
            unitBaseParameters.PageSize);
    }

    public async Task<UnitBase?> GetUnitBaseByIdAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(u => u.Id.Equals(id), trackChanges)
            .Include(u => u.Units)
            .SingleOrDefaultAsync();
    }

    public void CreateUnitBase(UnitBase unitBase)
    {
        Create(unitBase);
    }

    public void DeleteUnitBase(UnitBase unitBase)
    {
        Delete(unitBase);
    }

    public async Task<List<UnitBase>> GetAllUnitBases()
    {
        return await FindAll(false)
            .SortGeneric("Name", "asc")
            .ToListAsync();
    }
}