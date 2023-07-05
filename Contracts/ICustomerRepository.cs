using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface ICustomerRepository
{
    Task<PagedList<Customer>> GetCustomersAsync(CustomerParameters parameters, bool trackChanges);
    void CreateCustomer(Customer supplier);
    Task<Customer?> GetCustomerByIdAsync(Guid id, bool trackChanges);
    void DeleteCustomer(Customer supplier);
}