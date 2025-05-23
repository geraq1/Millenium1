using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class Maintenance
{
    public int MaintenanceId { get; set; }

    public int EquipmentId { get; set; }

    public DateOnly MaintenanceDate { get; set; }

    public string MaintenanceType { get; set; } = null!;

    public string? MaintenanceDescription { get; set; }

    public DateOnly? NextMaintenanceDate { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;
}
