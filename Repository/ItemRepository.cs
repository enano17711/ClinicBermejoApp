using Contracts;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class ItemRepository : RepositoryBase<Item>,
    IItemRepository
{
    public ItemRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Item>> GetItemsAsync(ItemParameters parameters,
        bool trackChanges)
    {
        var items = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn,
                parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn,
                parameters.SortOrder)
            .Include(i => i.Brand)
            .Include(i => i.Units)
            .Include(i => i.CategoryItems)
            .ToListAsync();

        return PagedList<Item>.ToPagedList(items,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Item?> GetItemByIdAsync(Guid id,
        bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(i => i.Brand)
            .Include(i => i.Units)
            .Include(i => i.CategoryItems)
            .SingleOrDefaultAsync();
    }

    public async Task<Item?> GetItemByAllotmentAsync(Guid id, string allotment,
        bool trackChanges)
    {
        return await FindByCondition(i => i.Id.Equals(id) && i.Allotment.ToLower()
                    .Equals(allotment.ToLower()),
                trackChanges)
            .SingleOrDefaultAsync();
    }


    public void CreateItem(Item item)
    {
        Create(item);
    }

    public void DeleteItem(Item item)
    {
        Delete(item);
    }
}