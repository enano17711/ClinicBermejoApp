using Contracts;
using Entities.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class DetailOrderRepository : RepositoryBase<DetailOrder>,
    IDetailOrderRepository
{
    public DetailOrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<DetailOrder>> GetDetailOrdersAsync(DetailOrderParameters parameters,
        bool trackChanges)
    {
        var detailOrders = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(dm => dm.Order)
            .Include(dm => dm.Item)
            .ToListAsync();

        return PagedList<DetailOrder>.ToPagedList(detailOrders,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<DetailOrder?> GetDetailOrderByIdAsync(Guid id,
        bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(dm => dm.Order)
            .Include(dm => dm.Item)
            .SingleOrDefaultAsync();
    }

    public void CreateDetailOrder(DetailOrder detailOrder)
    {
        Create(detailOrder);
    }

    public void DeleteDetailOrder(DetailOrder detailOrder)
    {
        Delete(detailOrder);
    }
}