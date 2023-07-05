using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class CustomerRepository : RepositoryBase<Customer>,
    ICustomerRepository
{
    public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Customer>> GetCustomersAsync(CustomerParameters parameters,
        bool trackChanges)
    {
        var customers = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(s => s.Sales)
            .ToListAsync();

        return PagedList<Customer>.ToPagedList(customers,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id,
        bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(s => s.Sales)
            .SingleOrDefaultAsync();
    }

    public void CreateCustomer(Customer customer)
    {
        Create(customer);
    }

    public void DeleteCustomer(Customer customer)
    {
        Delete(customer);
    }
}