using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Orders;

namespace Entities.Models.Items;

public class Unit : BaseItem
{
    [Column("UnitId")] public Guid Id { get; set; }

    [Required(ErrorMessage = "El nombre corto es requerido")]
    [MaxLength(50, ErrorMessage = "El nombre corto no puede tener más de 50 caracteres")]
    public string? ShortName { get; set; }

    [Required(ErrorMessage = "La cantidad es requerida")]
    [Range(1, uint.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public uint Value { get; set; }

    [Required(ErrorMessage = "La operación es requerida")]
    public string? Operation { get; set; }

    [ForeignKey(nameof(UnitBase))] public Guid? UnitBaseId { get; set; }
    public UnitBase? UnitBase { get; set; }
    public ICollection<Item>? Items { get; set; }
    public ICollection<ItemUnit>? ItemUnits { get; set; }
    public ICollection<DetailOrder>? DetailOrders { get; set; }
}