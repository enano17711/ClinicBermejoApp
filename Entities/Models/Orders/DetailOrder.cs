﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Orders;

/// <summary>
///     Represents a detail order item.
/// </summary>
public class DetailOrder
{
    /// <summary>
    ///     Gets or sets the ID of the detail order.
    /// </summary>
    [Column("DetailOrderId")]
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets the cost of the item.
    /// </summary>
    [Required(ErrorMessage = "El Costo del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemCost { get; set; }

    /// <summary>
    ///     Gets or sets the tax amount for the item.
    /// </summary>
    [Required(ErrorMessage = "El Impuesto del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemTax { get; set; }

    /// <summary>
    ///     Gets or sets the discount amount for the item.
    /// </summary>
    [Required(ErrorMessage = "El Descuento del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemDiscount { get; set; }

    /// <summary>
    ///     Gets or sets the total amount for the item.
    /// </summary>
    [Required(ErrorMessage = "El Total del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemTotal { get; set; }

    /// <summary>
    ///     Gets or sets the quantity of the item.
    /// </summary>
    [Required(ErrorMessage = "La Cantidad es requerida")]
    [Range(0, uint.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public uint DetailOrderItemQuantity { get; set; }

    /// <summary>
    ///     Gets or sets the number of single units for the item.
    /// </summary>
    [Required(ErrorMessage = "Las unidades sueltas son requeridas")]
    [Range(0, uint.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public uint DetailOrderItemSingleUnits { get; set; }

    /// <summary>
    ///     Gets or sets the date of the item.
    /// </summary>
    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime DetailOrderItemDate { get; set; }

    /// <summary>
    ///     Gets or sets the allotment of the item.
    /// </summary>
    public string? DetailItemAllotment { get; set; }

    /// <summary>
    ///     Gets or sets the expiration date of the item.
    /// </summary>
    [Required(ErrorMessage = "La fecha de expiracion es requerida")]
    public DateTime DetailOrderItemExpiration { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the associated item.
    /// </summary>
    [ForeignKey(nameof(Item))]
    public Guid? ItemId { get; set; }

    /// <summary>
    ///     Gets or sets the associated item.
    /// </summary>
    public Item? Item { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the associated unit.
    /// </summary>
    [ForeignKey(nameof(Unit))]
    public Guid? UnitId { get; set; }

    /// <summary>
    ///     Gets or sets the associated unit.
    /// </summary>
    public Unit? Unit { get; set; }

    /// <summary>
    ///     Gets or sets the ID of the associated order.
    /// </summary>
    [ForeignKey(nameof(Order))]
    public Guid? OrderId { get; set; }

    /// <summary>
    ///     Gets or sets the associated order.
    /// </summary>
    public Order? Order { get; set; }
}