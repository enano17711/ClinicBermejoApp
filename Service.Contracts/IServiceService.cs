using Shared.RequestFeatures;
using Shared.Services;

namespace Service.Contracts;

public interface IServiceService
{
    Task<(IEnumerable<ServiceDto> services, MetaData metaData)> GetServicesAsync(ServiceParameters parameters,
        bool trackChanges);

    Task<ServiceDto> GetServiceByIdAsync(Guid id, bool trackChanges);
    Task<ServiceDto> CreateServiceAsync(ServiceForCreationDto service);
    Task DeleteServiceAsync(Guid id, bool trackChanges);
    Task UpdateServiceAsync(Guid id, ServiceForUpdateDto service, bool trackChanges);
}