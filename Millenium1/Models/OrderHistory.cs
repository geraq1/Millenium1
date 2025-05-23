using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class OrderHistory
{
    public int Histid { get; set; }

    public long Clientid { get; set; }

    public int Orderid { get; set; }

    public DateOnly Date { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
