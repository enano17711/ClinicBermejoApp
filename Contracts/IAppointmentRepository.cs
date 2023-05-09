using Entities.Models.Appointments;
using Shared.RequestFeatures;

namespace Contracts;

public interface IAppointmentRepository
{
    Task<PagedList<Appointment>> GetAppointmentsAsync(AppointmentParameters parameters, bool trackChanges);
    void CreateAppointment(Appointment appointment);
    Task<Appointment?> GetAppointmentByIdAsync(Guid id, bool trackChanges);
    void DeleteAppointment(Appointment appointment);
}