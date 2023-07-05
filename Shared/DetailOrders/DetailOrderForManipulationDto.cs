using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.DetailOrders;

public abstract record DetailOrderForManipulationDto
{
    [Required(ErrorMessage = "El Monto es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La Cantidad debe ser positiva")]
    [Precision(18, 2)]
    public decimal Quantity { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime Date { get; set; }

    public string? Allotment { get; set; }

    [Required(ErrorMessage = "El tipo de Vencimiento es requerido")]
    public char IsAllotment { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ItemId { get; set; }
}