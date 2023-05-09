using Shared.Appointments;
using Shared.Doctors;
using Shared.Nurses;

namespace Shared.Patients;

public record PatientDto
{
    public Guid Id { get; init; }

    public string? ClinicHistory { get; init; }

    public string? Name { get; init; }

    public string? Surname { get; init; }

    public string? Ci { get; init; }

    public string? Email { get; init; }

    public string? PhoneNumber { get; init; }

    public DateTime? Date { get; init; }

    public string? Address { get; init; }

    public DoctorForViewDto? Doctor { get; init; }

    public NurseForViewDto? Nurse { get; init; }

    public IEnumerable<AppointmentForViewDto>? Appointments { get; init; }
}