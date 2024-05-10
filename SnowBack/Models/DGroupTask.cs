using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DGroupTask
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public DateTime Created { get; set; }
}
