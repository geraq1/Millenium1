using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Fabric
{
    public int FabricId { get; set; }

    public string FabName { get; set; } = null!;

    public decimal PricePerMeter { get; set; }

    public string? Description { get; set; }

    public string MaterialType { get; set; } = null!;

    public int? SupplierId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual Supplier? Supplier { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
