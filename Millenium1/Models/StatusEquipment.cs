using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class StatusEquipment
{
    public int StatusEquipmentId { get; set; }

    public string StatusEquipmentNm { get; set; } = null!;

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
