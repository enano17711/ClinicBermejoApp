using Contracts;
using Entities.Models.Appointments;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

public class AppointmentRepository : RepositoryBase<Appointment>,
    IAppointmentRepository
{
    public AppointmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<PagedList<Appointment>> GetAppointmentsAsync(AppointmentParameters parameters,
        bool trackChanges)
    {
        var appointments = await FindAll(trackChanges)
            .SearchGeneric(parameters.SearchColumn, parameters.SearchTerm)
            .SortGeneric(parameters.SortColumn, parameters.SortOrder)
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .Include(a => a.Nurse)
            .Include(a => a.AppointmentDoctors)
            .ToListAsync();

        return PagedList<Appointment>.ToPagedList(appointments,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<Appointment?> GetAppointmentByIdAsync(Guid id,
        bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id),
                trackChanges)
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .Include(a => a.Nurse)
            .Include(a => a.AppointmentDoctors)
            .SingleOrDefaultAsync();

    public void CreateAppointment(Appointment appointment) =>
        Create(appointment);

    public void DeleteAppointment(Appointment appointment) =>
        Delete(appointment);
}