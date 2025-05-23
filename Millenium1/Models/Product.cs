using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int? EquipmentId { get; set; }

    public int CategoryId { get; set; }

    public int? FabricId { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<Defect> Defects { get; set; } = new List<Defect>();

    public virtual Equipment? Equipment { get; set; }

    public virtual Fabric? Fabric { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
