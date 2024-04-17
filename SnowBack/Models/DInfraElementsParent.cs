using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DInfraElementsParent
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int? Objectid { get; set; }

    public int? Parentid { get; set; }
}
