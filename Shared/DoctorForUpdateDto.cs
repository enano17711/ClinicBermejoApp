namespace Shared;

public record DoctorForUpdateDto : DoctorForManipulationDto
{
    public string? RegisterNumber { get; init; }

    public Specialty Specialty { get; init; }

    //public IEnumerable<PatientDto>? Patients { get; init; }
}