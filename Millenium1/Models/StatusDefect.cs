using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class StatusDefect
{
    public int StatusDefectsId { get; set; }

    public string StatusDefectsNm { get; set; } = null!;

    public virtual ICollection<Defect> Defects { get; set; } = new List<Defect>();
}
