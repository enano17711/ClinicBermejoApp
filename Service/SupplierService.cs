using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.Suppliers;

namespace Service;

public class SupplierService : ISupplierService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public SupplierService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<SupplierDto> suppliers, MetaData metaData)> GetSuppliersAsync(
        SupplierParameters parameters,
        bool trackChanges)
    {
        var suppliersWithMetaData = await _repository.Suppliers.GetSuppliersAsync(parameters, trackChanges);
        var suppliersDto = _mapper.Map<IEnumerable<SupplierDto>>(suppliersWithMetaData);

        return (suppliersDto, suppliersWithMetaData.MetaData);
    }

    public async Task<SupplierDto> GetSupplierByIdAsync(Guid id, bool trackChanges)
    {
        var supplier = await GetSupplierAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<SupplierDto>(supplier);
    }

    public async Task<SupplierDto> CreateSupplierAsync(SupplierForCreationDto supplier)
    {
        var supplierEntity = _mapper.Map<Supplier>(supplier);
        _repository.Suppliers.CreateSupplier(supplierEntity);
        await _repository.SaveAsync();
        return _mapper.Map<SupplierDto>(supplierEntity);
    }

    public async Task DeleteSupplierAsync(Guid id, bool trackChanges)
    {
        var supplier = await GetSupplierAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Suppliers.DeleteSupplier(supplier);
        await _repository.SaveAsync();
    }

    public async Task UpdateSupplierAsync(Guid id, SupplierForUpdateDto supplier, bool trackChanges)
    {
        var supplierEntity = await GetSupplierAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(supplier, supplierEntity);
        await _repository.SaveAsync();
    }

    private async Task<Supplier> GetSupplierAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var supplier = await _repository.Suppliers.GetSupplierByIdAsync(id, trackChanges);
        if (supplier is null) throw new SupplierNotFoundException(id);
        return supplier;
    }
}