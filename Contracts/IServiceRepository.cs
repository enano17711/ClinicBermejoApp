using Entities.Models.Services;
using Shared.RequestFeatures;

namespace Contracts;

public interface IServiceRepository
{
    Task<PagedList<Service>> GetServicesAsync(ServiceParameters parameters, bool trackChanges);
    void CreateService(Service service);
    Task<Service?> GetServiceByIdAsync(Guid id, bool trackChanges);
    void DeleteService(Service service);
}