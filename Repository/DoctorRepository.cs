using Contracts;
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
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(d => d.Appointments)!
            .ThenInclude(ap => ap.Patient)
            .Include(d => d.Appointments)!
            .ThenInclude(ap => ap.Nurse)
            .Include(d => d.ServiceDoctors)!
            .ThenInclude(sd => sd.Service)
            .Include(d => d.AppointmentDoctors)
            .Include(d => d.Patients)
            .ToListAsync();

        return PagedList<Doctor>.ToPagedList(doctors,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Doctor?> GetDoctorByIdAsync(Guid id,
        bool trackChanges)
    {
        return await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(d => d.Appointments)!
            .ThenInclude(ap => ap.Patient)
            .Include(d => d.Appointments)!
            .ThenInclude(ap => ap.Nurse)
            .Include(d => d.ServiceDoctors)!
            .ThenInclude(sd => sd.Service)
            .Include(d => d.AppointmentDoctors)
            .Include(d => d.Patients)
            .SingleOrDefaultAsync();
    }

    public void CreateDoctor(Doctor doctor)
    {
        Create(doctor);
    }

    public void DeleteDoctor(Doctor doctor)
    {
        Delete(doctor);
    }
}