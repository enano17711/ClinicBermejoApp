using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Movements;

public class Movement
{
    [Column("MovementId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "El Monto es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El Monto debe ser positivo")]
    [Precision(18, 2)]
    public decimal TotalCost { get; set; }

    [Required(ErrorMessage = "La Cantidad es requerida")]
    public uint TotalQuantity { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida")]
    public DateTime? Date { get; set; }

    [ForeignKey(nameof(Supplier))] public Guid? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    [ForeignKey(nameof(Note))] public Guid? NoteId { get; set; }
    public Note? Note { get; set; }
    public ICollection<DetailMovement>? DetailMovements { get; set; }
}