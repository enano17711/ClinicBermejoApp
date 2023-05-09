using Contracts;
using Entities.Models.Appointments;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class AppointmentDoctorRepository : RepositoryBase<AppointmentDoctor>,
    IAppointmentDoctorRepository
{
    public AppointmentDoctorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<AppointmentDoctor>> GetAppointmentDoctorsAsync(AppointmentDoctorParameters parameters,
        bool trackChanges)
    {
        var appointmentDoctors = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(ad => ad.Appointment)
            .Include(ad => ad.Doctor)
            .ToListAsync();

        return PagedList<AppointmentDoctor>.ToPagedList(appointmentDoctors,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<AppointmentDoctor?> GetAppointmentDoctorByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(ad => ad.Appointment)
            .Include(ad => ad.Doctor)
            .SingleOrDefaultAsync();

    public void CreateAppointmentDoctor(AppointmentDoctor appointmentDoctor) =>
        Create(appointmentDoctor);

    public void DeleteAppointmentDoctor(AppointmentDoctor appointmentDoctor) =>
        Delete(appointmentDoctor);
}