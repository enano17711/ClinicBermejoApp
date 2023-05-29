using Contracts;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class UnitRepository : RepositoryBase<Unit>,
    IUnitRepository
{
    public UnitRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Unit>> GetUnitsAsync(UnitParameters parameters,
        bool trackChanges)
    {
        var units = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(u=>u.Items)
            .ToListAsync();

        return PagedList<Unit>.ToPagedList(units,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Unit?> GetUnitByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(u=>u.Items)
            .SingleOrDefaultAsync();

    public void CreateUnit(Unit unit) =>
        Create(unit);

    public void DeleteUnit(Unit unit) =>
        Delete(unit);
}