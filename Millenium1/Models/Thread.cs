using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Thread
{
    public int ThreadId { get; set; }

    public string Color { get; set; } = null!;

    public string MaterialType { get; set; } = null!;

    public decimal PricePerSpool { get; set; }

    public int SupplierId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;
}
