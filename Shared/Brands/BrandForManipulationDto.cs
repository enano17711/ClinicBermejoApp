using System.ComponentModel.DataAnnotations;

namespace Shared.Brands;

public abstract record BrandForManipulationDto
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public string? Name { get; init; }

    [MaxLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
    public string? Description { get; init; }
}