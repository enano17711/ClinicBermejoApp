using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models.Items;

public class Item : BaseItem
{
    [Column("ItemId")] public Guid Id { get; set; }
    public string? Code { get; set; }

    [Required(ErrorMessage = "El stock es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El stock debe ser positivo")]
    [Precision(18, 2)]
    public decimal? StockItem { get; set; }

    public string? Allotment { get; set; }
    public DateTime? Expiration { get; set; }

    [ForeignKey(nameof(Brand))] public Guid? BrandId { get; set; }
    public Brand? Brand { get; set; }
    public ICollection<CategoryItem>? CategoryItems { get; set; }
    public ICollection<CategoryItemMN>? CategoryItemMNs { get; set; }
    public ICollection<Unit>? Units { get; set; }
    public ICollection<ItemUnit>? ItemUnits { get; set; }
    public ICollection<DetailOrder>? DetailOrders { get; set; }
}