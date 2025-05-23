using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Client
{
    public long Clientid { get; set; }

    public string ClientFio { get; set; } = null!;

    public string ClientEmail { get; set; } = null!;

    public virtual ICollection<ClientElement> ClientElements { get; set; } = new List<ClientElement>();

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
