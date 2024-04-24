using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DInfraElementsFunction
{
    public int Id { get; set; }

    public int Type { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public virtual DInfraElementsType TypeNavigation { get; set; } = null!;
}
