using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Movements;

namespace Entities.Models.Items;

public class Unit : BaseItem
{
    [Column("UnitId")] public Guid Id { get; set; }

    public ICollection<ItemUnit>? ItemUnits { get; set; }
    
    public ICollection<DetailMovement>? DetailMovements { get; set; }
}