using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Items;

namespace Entities.Models.Movements;

public class DetailMovement
{
    [Column("DetailMovementId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "El Monto es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La Cantidad debe ser positiva")]
    public decimal Quantity { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime Date { get; set; }

    public string? Allotment { get; set; }

    [Required(ErrorMessage = "El tipo de Vencimiento es requerido")]
    public char IsAllotment { get; set; }

    [ForeignKey(nameof(Movement))] public Guid? MovementId { get; set; }
    public Movement? Movement { get; set; }

    [ForeignKey(nameof(Item))] public Guid? ItemId { get; set; }
    public Item? Item { get; set; }
}