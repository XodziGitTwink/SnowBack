using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JTask
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int Task { get; set; }

    public int? Element { get; set; }

    public int Executor { get; set; }

    public DateTime Dateon { get; set; }

    public DateTime Dateoff { get; set; }

    public string Emergency { get; set; } = null!;

    public int? Creator { get; set; }

    public string? Description { get; set; }

    public bool IsGroup { get; set; }

    public int? GroupId { get; set; }

    public bool? IsActive { get; set; } = false;

    public bool? IsComplete { get; set; } = false;
}
