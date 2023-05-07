using System.ComponentModel.DataAnnotations;

namespace Shared.Doctors;

public record DoctorForCreationDto : DoctorForManipulationDto
{
    [Required(ErrorMessage = "La Matricula es requerida")]
    public string? RegisterNumber { get; init; }

    [Required(ErrorMessage = "La Especialidad es requerido")]
    public Specialty Specialty { get; init; } = Specialty.General;

    // Repair model/entity relations
    //public IEnumerable<PatientForCreationDto>? Patients { get; init; }
}