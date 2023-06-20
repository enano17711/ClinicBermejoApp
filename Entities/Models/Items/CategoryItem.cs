using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Items;

public class CategoryItem : BaseItem
{
    [Column("CategoryId")] public Guid Id { get; set; }

    public ICollection<Item>? Items { get; set; }
    public ICollection<CategoryItemMN>? CategoryItemMNs { get; set; }
}