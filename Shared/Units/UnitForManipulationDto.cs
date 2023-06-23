using System.ComponentModel.DataAnnotations;

namespace Shared.Units;

public abstract record UnitForManipulationDto
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public string? Name { get; set; }

    [MaxLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "El nombre corto es requerido")]
    [MaxLength(50, ErrorMessage = "El nombre corto no puede tener más de 50 caracteres")]
    public string? ShortName { get; set; }

    [Required(ErrorMessage = "La cantidad es requerida")]
    [Range(1, uint.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public uint Value { get; set; }

    [Required(ErrorMessage = "La operación es requerida")]
    public string? Operation { get; set; }

    public Guid? UnitBaseId { get; set; }
}