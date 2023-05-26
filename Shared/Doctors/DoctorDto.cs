using Shared.AppointmentDoctors;
using Shared.Appointments;
using Shared.Patients;
using Shared.ServiceDoctors;

namespace Shared.Doctors;

public record DoctorDto
{
    public Guid Id { get; init; }

    public string? RegisterNumber { get; init; }

    public Specialty Specialty { get; init; }

    public string? Name { get; init; }

    public string? Surname { get; init; }

    public string? Ci { get; init; }

    public string? Email { get; init; }

    public string? PhoneNumber { get; init; }

    public DateTime? Date { get; init; }

    public string? Address { get; init; }

    public IEnumerable<AppointmentForDoctorViewDto>? Appointments { get; init; }

    public IEnumerable<PatientForViewDto>? Patients { get; set; }

    public IEnumerable<ServiceDoctorForDoctorViewDto>? ServiceDoctors { get; set; }

    public IEnumerable<AppointmentDoctorForDoctorViewDto>? AppointmentDoctors { get; set; }
}