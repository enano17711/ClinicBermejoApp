using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Orders;

public class Note
{
    [Column("NoteId")] public Guid Id { get; set; }

    //[Required(ErrorMessage = "El nombre es requerido")]
    //[MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
    //public string? Name { get; set; }

    //[MaxLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
    //public string? Description { get; set; }

    //[Required(ErrorMessage = "El Tipo de Movimiento es requerido")]
    //public AdjustmentType Type { get; set; }

    //public ICollection<Order>? Orders { get; set; }
}

public enum AdjustmentType
{
    Positive,
    Negative
}