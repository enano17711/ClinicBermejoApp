using Contracts;
using Entities.Models;
using Entities.Models.Staff;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class DoctorRepository : RepositoryBase<Doctor>,
    IDoctorRepository
{
    public DoctorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Doctor>> GetDoctorsAsync(DoctorParameters parameters,
        bool trackChanges)
    {
        var doctors = await FindAll(trackChanges)
            .Filter(parameters.Specialty)
            .Search(parameters.SearchColumn, parameters.SearchTerm)
            .Sort(parameters.SortColumn, parameters.SortOrder)
            .ToListAsync();

        return PagedList<Doctor>.ToPagedList(doctors,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Doctor?> GetDoctorByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .SingleOrDefaultAsync();

    public void CreateDoctor(Doctor doctor) =>
        Create(doctor);

    public void DeleteDoctor(Doctor doctor) =>
        Delete(doctor);
}