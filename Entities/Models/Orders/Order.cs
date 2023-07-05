using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Orders;

public class Order
{
    [Column("OrderId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "El costo total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal OrderTotalItemsCost { get; set; }

    [Required(ErrorMessage = "El valor de impuestos total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public decimal OrderTotalItemsTax { get; set; }

    [Required(ErrorMessage = "El descuento total de los items es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public decimal OrderTotalItemsDiscount { get; set; }

    [Required(ErrorMessage = "La Impuesto de la compra es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public decimal OrderTax { get; set; }

    [Required(ErrorMessage = "El descuento de la compra es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public decimal OrderDiscount { get; set; }

    [Required(ErrorMessage = "La Impuesto de la compra es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public decimal OrderCost { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? OrderDate { get; set; }
    public string? OrderNote { get; set; }

    [ForeignKey(nameof(Supplier))] public Guid? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    public ICollection<DetailOrder>? DetailOrders { get; set; }
}