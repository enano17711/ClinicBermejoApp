using Contracts;
using Entities.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class OrderRepository : RepositoryBase<Order>,
    IOrderRepository
{
    public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Order>> GetOrdersAsync(OrderParameters parameters,
        bool trackChanges)
    {
        var orders = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(o => o.Note)
            .Include(o => o.Supplier)
            .Include(o => o.DetailOrders)
            .ToListAsync();

        return PagedList<Order>.ToPagedList(orders,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Order?> GetOrderByIdAsync(Guid id,
        bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(o => o.Note)
            .Include(m => m.Supplier)
            .Include(m => m.DetailOrders)
            .SingleOrDefaultAsync();
    }

    public void CreateOrder(Order order)
    {
        Create(order);
    }

    public void DeleteOrder(Order order)
    {
        Delete(order);
    }
}