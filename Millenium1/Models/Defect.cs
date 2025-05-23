using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Defect
{
    public int DefectId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string Description { get; set; } = null!;

    public int? StatusDefectsId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual StatusDefect? StatusDefects { get; set; }
}
