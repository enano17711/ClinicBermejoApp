using Contracts;
using Entities.Models.Services;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class ServiceRepository : RepositoryBase<Service>,
    IServiceRepository
{
    public ServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Service>> GetServicesAsync(ServiceParameters parameters,
        bool trackChanges)
    {
        var services = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .ToListAsync();

        return PagedList<Service>.ToPagedList(services,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Service?> GetServiceByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .SingleOrDefaultAsync();

    public void CreateService(Service service) =>
        Create(service);

    public void DeleteService(Service service) =>
        Delete(service);
}