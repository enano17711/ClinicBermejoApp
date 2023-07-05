using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Orders;

namespace Entities.Models.Items;

public class Item : BaseItem
{
    [Column("ItemId")] public Guid Id { get; set; }
    public string? Code { get; set; }
    [ForeignKey(nameof(Brand))] public Guid? BrandId { get; set; }
    public Brand? Brand { get; set; }
    public ICollection<CategoryItem>? CategoryItems { get; set; }
    public ICollection<CategoryItemMN>? CategoryItemMNs { get; set; }
    public ICollection<Unit>? Units { get; set; }
    public ICollection<ItemUnit>? ItemUnits { get; set; }
    public ICollection<DetailOrder>? DetailOrders { get; set; }
}