using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.Services;

namespace Service;

public class ServiceService : IServiceService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public ServiceService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<ServiceDto> services, MetaData metaData)> GetServicesAsync(
        ServiceParameters parameters,
        bool trackChanges)
    {
        var servicesWithMetaData = await _repository.Services.GetServicesAsync(parameters, trackChanges);
        var servicesDto = _mapper.Map<IEnumerable<ServiceDto>>(servicesWithMetaData);

        return (servicesDto, servicesWithMetaData.MetaData);
    }

    public async Task<ServiceDto> GetServiceByIdAsync(Guid id, bool trackChanges)
    {
        var service = await GetServiceAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<ServiceDto>(service);
    }

    public async Task<ServiceDto> CreateServiceAsync(ServiceForCreationDto service)
    {
        var serviceEntity = _mapper.Map<Entities.Models.Services.Service>(service);
        _repository.Services.CreateService(serviceEntity);
        await _repository.SaveAsync();
        return _mapper.Map<ServiceDto>(serviceEntity);
    }

    public async Task DeleteServiceAsync(Guid id, bool trackChanges)
    {
        var service = await GetServiceAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.Services.DeleteService(service);
        await _repository.SaveAsync();
    }

    public async Task UpdateServiceAsync(Guid id, ServiceForUpdateDto service, bool trackChanges)
    {
        var serviceEntity = await GetServiceAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(service, serviceEntity);
        await _repository.SaveAsync();
    }

    private async Task<Entities.Models.Services.Service> GetServiceAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var service = await _repository.Services.GetServiceByIdAsync(id, trackChanges);
        if (service is null) throw new ServiceNotFoundException(id);
        return service;
    }
}