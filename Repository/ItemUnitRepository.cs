using Contracts;
using Entities.Models;
using Entities.Models.Items;
using Entities.Models.Staff;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class ItemUnitRepository : RepositoryBase<ItemUnit>,
    IItemUnitRepository
{
    public ItemUnitRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<ItemUnit>> GetItemUnitsAsync(ItemUnitParameters parameters,
        bool trackChanges)
    {
        var itemUnits = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(iu => iu.Item)
            .Include(iu => iu.Unit)
            .ToListAsync();

        return PagedList<ItemUnit>.ToPagedList(itemUnits,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<ItemUnit?> GetItemUnitByIdAsync(Guid itemId, Guid unitId,
        bool trackChanges) =>
        await FindByCondition(iu => iu.ItemId == itemId && iu.UnitId == unitId,
                trackChanges)
            .Include(iu => iu.Item)
            .Include(iu => iu.Unit)
            .SingleOrDefaultAsync();

    public void CreateItemUnit(ItemUnit itemUnit) =>
        Create(itemUnit);

    public void DeleteItemUnit(ItemUnit itemUnit) =>
        Delete(itemUnit);
}