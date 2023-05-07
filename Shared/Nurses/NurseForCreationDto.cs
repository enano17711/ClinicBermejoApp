﻿using System.ComponentModel.DataAnnotations;

namespace Shared.Nurses;

public record NurseForCreationDto : NurseForManipulationDto
{
    [Required(ErrorMessage = "La Matricula es requerida")]
    public string? RegisterNumber { get; init; }

    [Required(ErrorMessage = "La Especialidad es requerido")]
    public Specialty Specialty { get; init; } = Specialty.General;

    //public IEnumerable<PatientDto>? Patients { get; init; }
}