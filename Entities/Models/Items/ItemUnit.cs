﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Items;

public class ItemUnit
{
    [ForeignKey(nameof(Item))] public Guid? ItemId { get; set; }
    public Item? Item { get; set; }

    [ForeignKey(nameof(Unit))] public Guid? UnitId { get; set; }
    public Unit? Unit { get; set; }
}