using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JSnowGunsOrder
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int GunId { get; set; }

    public int? Point { get; set; }

    public int? Waterline { get; set; }

    public int? Powerline { get; set; }

    public DateOnly? Dateon { get; set; }

    public int? Direction { get; set; }

    public bool Status { get; set; }
}
