using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Items;

public class CategoryItem : BaseItem
{
    [Column("CategoryItemId")] public Guid CategoryItemId { get; set; }
    
    public ICollection<Item>? Items { get; set; }
}