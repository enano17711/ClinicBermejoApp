using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Items;

public class Unit
{
    [Column("UnitId")] public Guid Id { get; set; }

    public ICollection<Item>? Items { get; set; }
}