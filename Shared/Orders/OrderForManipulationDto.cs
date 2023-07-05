using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.Orders;

public abstract record OrderForManipulationDto
{
    [Required(ErrorMessage = "El Tipo de Movimiento es requerido")]
    public string? Type { get; set; }

    [Required(ErrorMessage = "El Monto es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La Cantidad debe ser positiva")]
    [Precision(18, 2)]
    public decimal Quantity { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? Date { get; set; }

    public Guid? SupplierId { get; set; }
}