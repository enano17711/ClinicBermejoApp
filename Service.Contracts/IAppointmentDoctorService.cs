using Shared.AppointmentDoctors;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IAppointmentDoctorService
{
    Task<(IEnumerable<AppointmentDoctorDto> appointmentDoctors, MetaData metaData)> GetAppointmentDoctorsAsync(
        AppointmentDoctorParameters parameters,
        bool trackChanges);

    Task<AppointmentDoctorDto> GetAppointmentDoctorByIdAsync(Guid id, bool trackChanges);
    Task<AppointmentDoctorDto> CreateAppointmentDoctorAsync(AppointmentDoctorForCreationDto appointmentDoctor);
    Task DeleteAppointmentDoctorAsync(Guid id, bool trackChanges);
    Task UpdateAppointmentDoctorAsync(Guid id, AppointmentDoctorForUpdateDto appointmentDoctor, bool trackChanges);
}