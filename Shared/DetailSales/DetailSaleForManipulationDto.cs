using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.DetailSales;

public abstract record DetailSaleForManipulationDto
{
    [Required(ErrorMessage = "El Costo del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailSaleItemCost { get; init; }

    [Required(ErrorMessage = "El Impuesto del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailSaleItemTax { get; init; }

    [Required(ErrorMessage = "El Descuento del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailSaleItemDiscount { get; init; }

    [Required(ErrorMessage = "El Total del item es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal DetailSaleItemTotal { get; init; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    [Range(0, uint.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public uint DetailSaleItemQuantity { get; init; }

    [Required(ErrorMessage = "Las unidades sueltas son requeridas")]
    [Range(0, uint.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public uint DetailSaleItemSingleUnits { get; init; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime DetailSaleItemDate { get; init; }

    public string? DetailItemAllotment { get; init; }

    [Required(ErrorMessage = "La fecha de expiracion es requerida")]
    public DateTime DetailSaleItemExpiration { get; init; }

    public Guid? ItemId { get; init; }
    public Guid? UnitId { get; init; }
    public Guid? SaleId { get; init; }
}