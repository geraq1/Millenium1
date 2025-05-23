using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class UserLoginAudit
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public DateTime LoginTime { get; set; }

    public string? IpAddress { get; set; }
}
