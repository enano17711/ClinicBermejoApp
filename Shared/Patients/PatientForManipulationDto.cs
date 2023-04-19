using System.ComponentModel.DataAnnotations;

namespace Shared.Patients;

public abstract record PatientForManipulationDto
{
    [Required(ErrorMessage = "La Historia Clínica es requerida")]
    public string? ClinicHistory { get; init; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "El apellido es requerido")]
    [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres")]
    public string? Surname { get; init; }

    [Required(ErrorMessage = "El Ci es requerido")]
    public string? Ci { get; init; }

    [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
    public string? Email { get; init; }

    [Required(ErrorMessage = "El número de teléfono es requerido")]
    public string? PhoneNumber { get; init; }

    public DateTime? Date { get; init; }

    public string? Address { get; init; }
}