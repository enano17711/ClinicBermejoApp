using Shared.RequestFeatures;
using Shared.ServiceDoctors;

namespace Service.Contracts;

public interface IServiceDoctorService
{
    Task<(IEnumerable<ServiceDoctorDto> serviceDoctors, MetaData metaData)> GetServiceDoctorsAsync(
        ServiceDoctorParameters parameters,
        bool trackChanges);

    Task<ServiceDoctorDto> GetServiceDoctorByIdAsync(Guid id, bool trackChanges);
    Task<ServiceDoctorDto> CreateServiceDoctorAsync(ServiceDoctorForCreationDto serviceDoctor);
    Task DeleteServiceDoctorAsync(Guid id, bool trackChanges);
    Task UpdateServiceDoctorAsync(Guid id, ServiceDoctorForUpdateDto serviceDoctor, bool trackChanges);
}