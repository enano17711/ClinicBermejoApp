using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models.Services;
using Service.Contracts;
using Shared.RequestFeatures;
using Shared.ServiceDoctors;

namespace Service;

public class ServiceDoctorService : IServiceDoctorService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public ServiceDoctorService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<(IEnumerable<ServiceDoctorDto> serviceDoctors, MetaData metaData)> GetServiceDoctorsAsync(
        ServiceDoctorParameters parameters,
        bool trackChanges)
    {
        var serviceDoctorsWithMetaData =
            await _repository.ServiceDoctors.GetServiceDoctorsAsync(parameters, trackChanges);
        var serviceDoctorsDto = _mapper.Map<IEnumerable<ServiceDoctorDto>>(serviceDoctorsWithMetaData);

        return (serviceDoctorsDto, serviceDoctorsWithMetaData.MetaData);
    }

    public async Task<ServiceDoctorDto> GetServiceDoctorByIdAsync(Guid id, bool trackChanges)
    {
        var serviceDoctor = await GetServiceDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        return _mapper.Map<ServiceDoctorDto>(serviceDoctor);
    }

    public async Task<ServiceDoctorDto> CreateServiceDoctorAsync(ServiceDoctorForCreationDto serviceDoctor)
    {
        var serviceDoctorEntity = _mapper.Map<ServiceDoctor>(serviceDoctor);
        _repository.ServiceDoctors.CreateServiceDoctor(serviceDoctorEntity);
        await _repository.SaveAsync();
        return _mapper.Map<ServiceDoctorDto>(serviceDoctorEntity);
    }

    public async Task DeleteServiceDoctorAsync(Guid id, bool trackChanges)
    {
        var serviceDoctor = await GetServiceDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _repository.ServiceDoctors.DeleteServiceDoctor(serviceDoctor);
        await _repository.SaveAsync();
    }

    public async Task UpdateServiceDoctorAsync(Guid id, ServiceDoctorForUpdateDto serviceDoctor, bool trackChanges)
    {
        var serviceDoctorEntity = await GetServiceDoctorAndCheckIfItExists(id: id, trackChanges: trackChanges);
        _mapper.Map(serviceDoctor, serviceDoctorEntity);
        await _repository.SaveAsync();
    }

    private async Task<ServiceDoctor> GetServiceDoctorAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var serviceDoctor = await _repository.ServiceDoctors.GetServiceDoctorByIdAsync(id, trackChanges);
        if (serviceDoctor is null) throw new ServiceDoctorNotFoundException(id);
        return serviceDoctor;
    }
}