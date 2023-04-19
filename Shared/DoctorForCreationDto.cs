using System.ComponentModel.DataAnnotations;

namespace Shared;

public record DoctorForCreationDto : DoctorForManipulationDto
{
    [Required(ErrorMessage = "La Matricula es requerida")]
    public string? RegisterNumber { get; init; }

    [Required(ErrorMessage = "La Especialidad es requerido")]
    public Specialty Specialty { get; init; }

    // Repair model/entity relations
    //public IEnumerable<PatientForCreationDto>? Patients { get; init; }
}