using Contracts;
using Entities.Models.Services;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class ServiceDoctorRepository : RepositoryBase<ServiceDoctor>,
    IServiceDoctorRepository
{
    public ServiceDoctorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<ServiceDoctor>> GetServiceDoctorsAsync(ServiceDoctorParameters parameters,
        bool trackChanges)
    {
        var serviceDoctors = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(sd => sd.Service)
            .Include(sd => sd.Doctor)
            .ToListAsync();

        return PagedList<ServiceDoctor>.ToPagedList(serviceDoctors,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<ServiceDoctor?> GetServiceDoctorByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(sd => sd.Service)
            .Include(sd => sd.Doctor)
            .SingleOrDefaultAsync();

    public void CreateServiceDoctor(ServiceDoctor serviceDoctor) =>
        Create(serviceDoctor);

    public void DeleteServiceDoctor(ServiceDoctor serviceDoctor) =>
        Delete(serviceDoctor);
}