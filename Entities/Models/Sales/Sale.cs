using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Sales;

/// <summary>
///     Represents a sale entity.
/// </summary>
public class Sale
{
    [Column("SaleId")] public Guid Id { get; set; }

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

    [Required(ErrorMessage = "La Impuesto de la venta es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTax { get; set; }

    [Required(ErrorMessage = "El descuento de la venta es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleDiscount { get; set; }

    [Required(ErrorMessage = "La Impuesto de la venta es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleCost { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? SaleDate { get; set; }

    public string? SaleNote { get; set; }

    [ForeignKey(nameof(Customer))] public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [ForeignKey(nameof(Note))] public Guid NoteId { get; set; }
    public Note? Note { get; set; }
    public ICollection<DetailSale>? DetailSales { get; set; }
}