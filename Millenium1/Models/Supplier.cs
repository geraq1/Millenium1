using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? SupplierEmail { get; set; }

    public string SupplierPhone { get; set; } = null!;

    public DateOnly? RegistrationDate { get; set; }

    public virtual ICollection<Fabric> Fabrics { get; set; } = new List<Fabric>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Thread> Threads { get; set; } = new List<Thread>();
}
