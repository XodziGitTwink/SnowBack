using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JTransportRent
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int? Task { get; set; }

    public DateTime Started { get; set; }

    public DateTime Finished { get; set; }

    public int Element { get; set; }

    public int Point { get; set; }

    public int Executor { get; set; }

    public string? Description { get; set; }
}
