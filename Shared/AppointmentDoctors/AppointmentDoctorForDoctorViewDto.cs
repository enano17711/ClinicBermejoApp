using Shared.Appointments;

namespace Shared.AppointmentDoctors;

public record AppointmentDoctorForDoctorViewDto
{
    public Guid Id { get; set; }

    public decimal CommissionPrice { get; set; }

    public AppointmentForViewDto? Appointment { get; set; }
}