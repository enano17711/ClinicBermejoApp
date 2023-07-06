using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.Items;

public abstract record ItemForManipulationDto
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    public string? Name { get; set; }

    public string? Code { get; init; }

    [Required(ErrorMessage = "El stock es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El stock debe ser positivo")]
    [Precision(18, 2)]
    public decimal? StockItem { get; set; }

    public string? Allotment { get; set; }

    [MaxLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
    public string? Description { get; set; }

    public Guid? BrandId { get; set; }
}