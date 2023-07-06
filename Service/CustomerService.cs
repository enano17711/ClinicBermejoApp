using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.Customers;
using Shared.RequestFeatures;

namespace Service;

public class CustomerService : ICustomerService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public CustomerService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<CustomerDto> customers, MetaData metaData)> GetCustomersAsync(
        CustomerParameters parameters,
        bool trackChanges)
    {
        var customersWithMetaData = await _repository.Customers.GetCustomersAsync(parameters, trackChanges);
        var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customersWithMetaData);

        return (customersDto, customersWithMetaData.MetaData);
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(Guid id, bool trackChanges)
    {
        var customer = await GetCustomerAndCheckIfItExists(id, trackChanges);
        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto> CreateCustomerAsync(CustomerForCreationDto customer)
    {
        var customerEntity = _mapper.Map<Customer>(customer);
        _repository.Customers.CreateCustomer(customerEntity);
        await _repository.SaveAsync();
        return _mapper.Map<CustomerDto>(customerEntity);
    }

    public async Task DeleteCustomerAsync(Guid id, bool trackChanges)
    {
        var customer = await GetCustomerAndCheckIfItExists(id, trackChanges);
        _repository.Customers.DeleteCustomer(customer);
        await _repository.SaveAsync();
    }

    public async Task UpdateCustomerAsync(Guid id, CustomerForUpdateDto customer, bool trackChanges)
    {
        var customerEntity = await GetCustomerAndCheckIfItExists(id, trackChanges);
        _mapper.Map(customer, customerEntity);
        await _repository.SaveAsync();
    }

    private async Task<Customer> GetCustomerAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var customer = await _repository.Customers.GetCustomerByIdAsync(id, trackChanges);
        if (customer is null) throw new CustomerNotFoundException(id);
        return customer;
    }
}