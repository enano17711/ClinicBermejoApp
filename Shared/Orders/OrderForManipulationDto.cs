using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.Orders;

public abstract record OrderForManipulationDto
{
    [Required(ErrorMessage = "El costo total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTotalItemsCost { get; set; }

    [Required(ErrorMessage = "El valor de impuestos total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTotalItemsTax { get; set; }

    [Required(ErrorMessage = "El descuento total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTotalItemsDiscount { get; set; }

    [Required(ErrorMessage = "La Impuesto de la compra es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTax { get; set; }

    [Required(ErrorMessage = "El descuento de la compra es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderDiscount { get; set; }

    [Required(ErrorMessage = "La Impuesto de la compra es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderCost { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? OrderDate { get; set; }

    public string? OrderNote { get; set; }
    public Guid? SupplierId { get; set; }
}