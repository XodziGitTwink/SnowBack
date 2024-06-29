using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DGood
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public int Type { get; set; }

    public string? Description { get; set; }

    public decimal Remain { get; set; }

    public DateTime DateOn { get; set; }
}
