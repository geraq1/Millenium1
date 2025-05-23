using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Administrator
{
    public int AdministratorId { get; set; }

    public string AdministratorFio { get; set; } = null!;

    public string? AdministratorEmail { get; set; }

    public string AdministratorPhone { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
