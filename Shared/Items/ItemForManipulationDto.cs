using System.ComponentModel.DataAnnotations;

namespace Shared.Items;

public abstract record ItemForManipulationDto
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public string? Name { get; set; }

    [MaxLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
    public string? Description { get; set; }

    public Guid? CategoryItemId { get; set; }

    public Guid? BrandId { get; set; }

    public Guid? UnitId { get; set; }
}