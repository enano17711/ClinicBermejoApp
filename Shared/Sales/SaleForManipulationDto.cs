using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.Sales;

public abstract record SaleForManipulationDto
{
    [Required(ErrorMessage = "El costo total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTotalItemsCost { get; set; }

    [Required(ErrorMessage = "El valor de impuestos total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTotalItemsTax { get; set; }

    [Required(ErrorMessage = "El descuento total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTotalItemsDiscount { get; set; }

    [Required(ErrorMessage = "La Impuesto de la compra es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTax { get; set; }

    [Required(ErrorMessage = "El descuento de la compra es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleDiscount { get; set; }

    [Required(ErrorMessage = "La Impuesto de la compra es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleCost { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? SaleDate { get; set; }

    public string? SaleNote { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? NoteId { get; set; }
}