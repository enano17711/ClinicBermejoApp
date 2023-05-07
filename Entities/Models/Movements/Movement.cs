using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Movements;

public class Movement
{
    [Column("MovementId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "El Tipo de Movimiento es requerido")]
    public string? Type { get; set; }

    [Required(ErrorMessage = "El Monto es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    [Range(0, double.MaxValue, ErrorMessage = "La Cantidad debe ser positiva")]
    public decimal Quantity { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? Date { get; set; }

    [ForeignKey(nameof(Supplier))] public Guid? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public ICollection<DetailMovement>? DetailMovements { get; set; }
}