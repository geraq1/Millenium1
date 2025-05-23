using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string EquipmentName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int? StatusEquipmentId { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual StatusEquipment? StatusEquipment { get; set; }
}
