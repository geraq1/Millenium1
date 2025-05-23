using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public int FabricId { get; set; }

    public decimal QuantityInStock { get; set; }

    public virtual Fabric Fabric { get; set; } = null!;
}
