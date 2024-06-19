using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DTmcFunction
{
    public int Id { get; set; }

    public Guid? Guid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public int TypeId { get; set; }
}
