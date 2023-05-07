using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Items;

public class Item : BaseItem
{
    [Column("ItemId")] public Guid Id { get; set; }

    [ForeignKey(nameof(CategoryItem))] public Guid? CategoryItemId { get; set; }
    public CategoryItem? CategoryItem { get; set; }

    [ForeignKey(nameof(Brand))] public Guid? BrandId { get; set; }
    public Brand? Brand { get; set; }

    [ForeignKey(nameof(Unit))] public Guid? UnitId { get; set; }
    public Unit? Unit { get; set; }
}