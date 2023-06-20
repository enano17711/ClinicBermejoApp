using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Items;

public class CategoryItemMN
{
    [ForeignKey(nameof(Item))] public Guid? ItemId { get; set; }
    public Item? Item { get; set; }

    [ForeignKey(nameof(CategoryItem))] public Guid? CategoryItemId { get; set; }
    public CategoryItem? CategoryItem { get; set; }
}