using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DTask
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public int? Position { get; set; }

    public bool Type { get; set; }

    public TimeOnly? Duration { get; set; }

    public DateTime Created { get; set; }
}
