using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class StaffPosition
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
