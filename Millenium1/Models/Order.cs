using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public int? AdministratorId { get; set; }

    public int? SewerId { get; set; }

    public int? FabricId { get; set; }

    public long Clientid { get; set; }

    public decimal TotalAmount { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly DueDate { get; set; }

    public int? StatusOrderId { get; set; }

    public virtual Administrator? Administrator { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Defect> Defects { get; set; } = new List<Defect>();

    public virtual Fabric? Fabric { get; set; }

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Sewer? Sewer { get; set; }

    public virtual StatusOrder? StatusOrder { get; set; }
}
