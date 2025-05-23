using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Sewer
{
    public int SewerId { get; set; }

    public string SewerFio { get; set; } = null!;

    public string SkillLevel { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
