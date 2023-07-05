using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Sales;

/// <summary>
///     Represents a sale entity.
/// </summary>
public class Sale
{
    /// <summary>
    ///     Gets or sets the sale ID.
    /// </summary>
    [Column("SaleId")]
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets the total cost of the items in the sale.
    /// </summary>
    [Required(ErrorMessage = "El costo total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTotalItemsCost { get; set; }

    /// <summary>
    ///     Gets or sets the total tax value of the items in the sale.
    /// </summary>
    [Required(ErrorMessage = "El valor de impuestos total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTotalItemsTax { get; set; }

    /// <summary>
    ///     Gets or sets the total discount value of the items in the sale.
    /// </summary>
    [Required(ErrorMessage = "El descuento total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTotalItemsDiscount { get; set; }

    /// <summary>
    ///     Gets or sets the tax value of the sale.
    /// </summary>
    [Required(ErrorMessage = "La Impuesto de la venta es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleTax { get; set; }

    /// <summary>
    ///     Gets or sets the discount value of the sale.
    /// </summary>
    [Required(ErrorMessage = "El descuento de la venta es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleDiscount { get; set; }

    /// <summary>
    ///     Gets or sets the cost of the sale.
    /// </summary>
    [Required(ErrorMessage = "La Impuesto de la venta es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal SaleCost { get; set; }

    /// <summary>
    ///     Gets or sets the date of the sale.
    /// </summary>
    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? SaleDate { get; set; }

    /// <summary>
    ///     Gets or sets the note for the sale.
    /// </summary>
    public string? SaleNote { get; set; }

    /// <summary>
    ///     Gets or sets the supplier ID associated with the sale.
    /// </summary>
    [ForeignKey(nameof(Customer))]
    public Guid? CustomerId { get; set; }

    /// <summary>
    ///     Gets or sets the supplier associated with the sale.
    /// </summary>
    public Customer? Customer { get; set; }

    /// <summary>
    ///     Gets or sets the collection of detail sales associated with the sale.
    /// </summary>
    public ICollection<DetailSale>? DetailOrders { get; set; }
}