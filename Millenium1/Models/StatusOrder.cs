using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class StatusOrder
{
    public int StatusOrderId { get; set; }

    public string StatusOrderNm { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
