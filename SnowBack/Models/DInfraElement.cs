using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DInfraElement
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Inventorycode { get; set; }

    public string? Gps { get; set; }

    public int Type { get; set; }

    public string? Description { get; set; }

}
