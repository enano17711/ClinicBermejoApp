using Entities.Models.Services;
using Shared.RequestFeatures;

namespace Contracts;

public interface IServiceDoctorRepository
{
    Task<PagedList<ServiceDoctor>> GetServiceDoctorsAsync(ServiceDoctorParameters parameters, bool trackChanges);
    void CreateServiceDoctor(ServiceDoctor serviceDoctor);
    Task<ServiceDoctor?> GetServiceDoctorByIdAsync(Guid id, bool trackChanges);
    void DeleteServiceDoctor(ServiceDoctor serviceDoctor);
}