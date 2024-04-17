using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JElementsState
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int? Element { get; set; }

    public int? User { get; set; }

    public DateTime Statuson { get; set; }

    public DateTime Status { get; set; }

    public string? Logfile { get; set; }

    public int? Source { get; set; }
}
