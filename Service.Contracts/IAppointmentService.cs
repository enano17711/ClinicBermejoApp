using Shared.Appointments;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IAppointmentService
{
    Task<(IEnumerable<AppointmentDto> appointments, MetaData metaData)> GetAppointmentsAsync(
        AppointmentParameters parameters,
        bool trackChanges);

    Task<AppointmentDto> GetAppointmentByIdAsync(Guid id, bool trackChanges);
    Task<AppointmentDto> CreateAppointmentAsync(AppointmentForCreationDto appointment);
    Task DeleteAppointmentAsync(Guid id, bool trackChanges);
    Task UpdateAppointmentAsync(Guid id, AppointmentForUpdateDto appointment, bool trackChanges);
}