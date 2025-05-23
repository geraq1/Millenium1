using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Request
{
    public int Requestid { get; set; }

    public int FabricId { get; set; }

    public int Supplierid { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateOnly Startdate { get; set; }

    public DateOnly? Enddate { get; set; }

    public bool Isdone { get; set; }

    public virtual Fabric Fabric { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
