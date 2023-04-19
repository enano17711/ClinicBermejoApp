namespace Shared;

public record NurseForUpdateDto : NurseForManipulationDto
{
    public string? RegisterNumber { get; init; }

    public Specialty Specialty { get; init; }

    //public IEnumerable<PatientDto>? Patients { get; init; }
}