using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Movements;

namespace Entities.Models.Items;

public class Item : BaseItem
{
    [Column("ItemId")] public Guid Id { get; set; }

    [ForeignKey(nameof(CategoryItem))] public Guid? CategoryItemId { get; set; }
    public CategoryItem? CategoryItem { get; set; }

    [ForeignKey(nameof(Brand))] public Guid? BrandId { get; set; }
    public Brand? Brand { get; set; }
    
    // public ICollection<ItemUnit>? ItemUnits { get; set; }
    public ICollection<Unit>? Units { get; set; }
    
    public ICollection<DetailMovement>? DetailMovements { get; set; }
}