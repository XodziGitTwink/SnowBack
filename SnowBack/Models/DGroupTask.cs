using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DGroupTask
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public DateTime Created { get; set; }

    public int? Creator { get; set; }

    public string? Description { get; set; }
}
