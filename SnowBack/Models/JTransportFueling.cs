using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JTransportFueling
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int? Task { get; set; }

    public DateTime Started { get; set; }

    public int Vehicle { get; set; }

    public int Point { get; set; }

    public int Userwho { get; set; }

    public int Good { get; set; }

    public string? Description { get; set; }
}
