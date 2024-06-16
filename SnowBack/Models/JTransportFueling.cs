using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JTransportFueling
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int Vehicle { get; set; }

    public int? Userwho { get; set; }

    public string? Fueltype { get; set; }

    public double? Fuelamount { get; set; }

    public int? Gasstation { get; set; }
}
