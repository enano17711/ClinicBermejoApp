using Shared.Customers;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface ICustomerService
{
    Task<(IEnumerable<CustomerDto> customers, MetaData metaData)> GetCustomersAsync(CustomerParameters parameters,
        bool trackChanges);

    Task<CustomerDto> GetCustomerByIdAsync(Guid id, bool trackChanges);
    Task<CustomerDto> CreateCustomerAsync(CustomerForCreationDto customer);
    Task DeleteCustomerAsync(Guid id, bool trackChanges);
    Task UpdateCustomerAsync(Guid id, CustomerForUpdateDto customer, bool trackChanges);
}