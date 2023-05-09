using Entities.Models.Appointments;
using Shared.RequestFeatures;

namespace Contracts;

public interface IAppointmentDoctorRepository
{
    Task<PagedList<AppointmentDoctor>> GetAppointmentDoctorsAsync(AppointmentDoctorParameters parameters,
        bool trackChanges);

    void CreateAppointmentDoctor(AppointmentDoctor appointmentDoctor);
    Task<AppointmentDoctor?> GetAppointmentDoctorByIdAsync(Guid id, bool trackChanges);
    void DeleteAppointmentDoctor(AppointmentDoctor appointmentDoctor);
}