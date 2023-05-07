using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Items;

public class Brand : BaseItem
{
    [Column("BrandId")] public Guid Id { get; set; }
    
    public ICollection<Item>? Items { get; set; }
}