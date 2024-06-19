using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JSnowGun
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Code { get; set; }

    public string? Point { get; set; }

    public int? Waterline { get; set; }

    public int? Powerline { get; set; }

    public byte? Nightorder { get; set; }

    public byte? DayOrder { get; set; }

    public DateOnly Dateon { get; set; }
}
