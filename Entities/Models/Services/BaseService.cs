using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Services;

public class BaseService
{
    [Required(ErrorMessage = "El Nombre es requerido")]
    [MaxLength(50, ErrorMessage = "El Nombre no puede tener más de 50 caracteres")]
    public string? Name { get; set; }

    [MaxLength(250, ErrorMessage = "La Descripción no puede tener más de 250 caracteres")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "El Precio es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Precio no puede ser negativo")]
    public decimal Price { get; set; }
}