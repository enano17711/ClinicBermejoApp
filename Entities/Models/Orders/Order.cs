using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Orders;

/// <summary>
///     Represents an order entity.
/// </summary>
public class Order
{
    /// <summary>
    ///     Gets or sets the order ID.
    /// </summary>
    [Column("OrderId")]
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets the total cost of the items in the order.
    /// </summary>
    [Required(ErrorMessage = "El costo total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTotalItemsCost { get; set; }

    /// <summary>
    ///     Gets or sets the total tax value of the items in the order.
    /// </summary>
    [Required(ErrorMessage = "El valor de impuestos total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTotalItemsTax { get; set; }

    /// <summary>
    ///     Gets or sets the total discount value of the items in the order.
    /// </summary>
    [Required(ErrorMessage = "El descuento total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTotalItemsDiscount { get; set; }

    /// <summary>
    ///     Gets or sets the tax value of the order.
    /// </summary>
    [Required(ErrorMessage = "La Impuesto de la compra es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTax { get; set; }

    /// <summary>
    ///     Gets or sets the discount value of the order.
    /// </summary>
    [Required(ErrorMessage = "El descuento de la compra es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderDiscount { get; set; }

    /// <summary>
    ///     Gets or sets the cost of the order.
    /// </summary>
    [Required(ErrorMessage = "La Impuesto de la compra es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderCost { get; set; }

    /// <summary>
    ///     Gets or sets the date of the order.
    /// </summary>
    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? OrderDate { get; set; }

    /// <summary>
    ///     Gets or sets the note for the order.
    /// </summary>
    public string? OrderNote { get; set; }

    /// <summary>
    ///     Gets or sets the supplier ID associated with the order.
    /// </summary>
    [ForeignKey(nameof(Supplier))]
    public Guid? SupplierId { get; set; }

    /// <summary>
    ///     Gets or sets the supplier associated with the order.
    /// </summary>
    public Supplier? Supplier { get; set; }

    /// <summary>
    ///     Gets or sets the collection of detail orders associated with the order.
    /// </summary>
    public ICollection<DetailOrder>? DetailOrders { get; set; }
}