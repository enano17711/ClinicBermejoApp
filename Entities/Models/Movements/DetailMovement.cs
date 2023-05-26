using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Movements;

public class DetailMovement
{
    [Column("DetailMovementId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "El Monto es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal Cost { get; set; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    public uint Quantity { get; set; }
    public uint SingleUnits { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime Date { get; set; }

    public string? Allotment { get; set; }

    [Required(ErrorMessage = "El tipo de Vencimiento es requerido")]
    public bool? IsAllotment { get; set; }

    [ForeignKey(nameof(Movement))] public Guid? MovementId { get; set; }
    public Movement? Movement { get; set; }

    [ForeignKey(nameof(Item))] public Guid? ItemId { get; set; }
    public Item? Item { get; set; }
    
    [ForeignKey(nameof(Unit))] public Guid? UnitId { get; set; }
    public Unit? Unit { get; set; }
}