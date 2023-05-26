using Shared.Nurses;
using Shared.Patients;

namespace Shared.Appointments;

public record AppointmentForDoctorViewDto
{
    public Guid Id { get; set; }

    public DateTime DateInit { get; set; }

    public DateTime DateEnd { get; set; }

    public decimal Price { get; set; }

    public PatientForViewDto? Patient { get; set; }

    public NurseForViewDto? Nurse { get; set; }
}