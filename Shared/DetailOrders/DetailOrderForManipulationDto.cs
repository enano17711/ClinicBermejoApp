using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.DetailOrders;

public abstract record DetailOrderForManipulationDto
{
    [Required(ErrorMessage = "El Costo del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemCost { get; init; }

    [Required(ErrorMessage = "El Impuesto del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemTax { get; init; }

    [Required(ErrorMessage = "El Descuento del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemDiscount { get; init; }

    [Required(ErrorMessage = "El Total del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailOrderItemTotal { get; init; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    [Range(0, uint.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public uint DetailOrderItemQuantity { get; init; }

    [Required(ErrorMessage = "Las unidades sueltas son requeridas")]
    [Range(0, uint.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public uint DetailOrderItemSingleUnits { get; init; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime DetailOrderItemDate { get; init; }

    public string? DetailItemAllotment { get; init; }

    [Required(ErrorMessage = "La fecha de expiracion es requerida")]
    public DateTime DetailOrderItemExpiration { get; init; }

    public Guid? ItemId { get; init; }
    public Guid? UnitId { get; init; }
    public Guid? OrderId { get; init; }
}