using System.ComponentModel.DataAnnotations;

namespace Shared.UnitBases;

public abstract record UnitBaseForManipulationDto
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "ShortName is required.")]
    [MaxLength(50, ErrorMessage = "ShortName cannot be longer than 50 characters.")]
    public string ShortName { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
    public string? Description { get; set; }
}