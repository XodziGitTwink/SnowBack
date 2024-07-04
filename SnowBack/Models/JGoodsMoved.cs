using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JGoodsMoved
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int? Task { get; set; }

    public int? Element { get; set; }

    public DateTime DateOn { get; set; }

    public int? Good { get; set; }

    public int? Source { get; set; }

    public string SourceAddr { get; set; } = null!;

    public int? Destination { get; set; }

    public string? DestinationAddr { get; set; }

    public int UserWho { get; set; }

    public int? UserWhom { get; set; }

    public bool Type { get; set; }
}
