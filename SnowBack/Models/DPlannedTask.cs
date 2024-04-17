using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DPlannedTask
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int Parenttask { get; set; }

    public int Task { get; set; }
}
