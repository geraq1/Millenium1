using System;
using System.Collections.Generic;

namespace Millenium1.Models;

public partial class ClientElement
{
    public int Elclientid { get; set; }

    public long Clientid { get; set; }

    public string Address { get; set; } = null!;

    public string Card { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;
}
