using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DStock
{
    public int Id { get; set; }

    public string? StockName { get; set; }

    public string? StockDesc { get; set; }

    public Guid? Guid { get; set; }
}
