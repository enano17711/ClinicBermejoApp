using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Movements;

namespace Entities.Models;

public class Supplier : BasePerson
{
    [Column("SupplierId")] public Guid Id { get; set; }

    [MaxLength(50, ErrorMessage = "El nit no puede tener más de 50 caracteres")]
    public string? Nit { get; set; }

    public ICollection<Movement>? Movements { get; set; }
}