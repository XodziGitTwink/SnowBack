using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JGood
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

    public decimal Qty { get; set; }

    public bool Deleted { get; set; }

    public int? DelUser { get; set; }

    public DateTime? DelDate { get; set; }

    public decimal Remain { get; set; }
}
