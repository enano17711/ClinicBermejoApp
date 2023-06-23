using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Items;

public class UnitBase : BaseItem
{
    [Column("UnitBaseId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "El nombre corto es requerido")]
    [MaxLength(50, ErrorMessage = "El nombre corto no puede tener más de 50 caracteres")]
    public string? ShortName { get; set; }
    public ICollection<Unit>? Units { get; set; }
}
