using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Orders;

/// <summary>
///     Represents a detail order item.
/// </summary>
public class DetailOrder
{
    [Column("DetailOrderId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "El Costo del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemCost { get; set; }

    [Required(ErrorMessage = "El Impuesto del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemTax { get; set; }

    [Required(ErrorMessage = "El Descuento del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemDiscount { get; set; }

    [Required(ErrorMessage = "El Total del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemTotal { get; set; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    [Range(0, uint.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public uint DetailOrderItemQuantity { get; set; }

    [Required(ErrorMessage = "Las unidades sueltas son requeridas")]
    [Range(0, uint.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public uint DetailOrderItemSingleUnits { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime DetailOrderItemDate { get; set; }

    public string? DetailItemAllotment { get; set; }


    [Required(ErrorMessage = "La fecha de expiracion es requerida")]
    public DateTime? DetailOrderItemExpiration { get; set; }

    [ForeignKey(nameof(Item))] public Guid ItemId { get; set; }
    public Item? Item { get; set; }

    [ForeignKey(nameof(Unit))] public Guid UnitId { get; set; }
    public Unit? Unit { get; set; }

    [ForeignKey(nameof(Order))] public Guid OrderId { get; set; }
    public Order? Order { get; set; }
}