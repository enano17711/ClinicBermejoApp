using Shared.Appointments;
using Shared.Doctors;

namespace Shared.AppointmentDoctors;

public record AppointmentDoctorDto
{
    public Guid Id { get; set; }

    public decimal CommissionPrice { get; set; }

    public AppointmentForViewDto? Appointment { get; set; }

    public DoctorForViewDto? Doctor { get; set; }
}