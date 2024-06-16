using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DRack
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string? RackName { get; set; }

    public string? RackDescription { get; set; }

    public Guid? Guid { get; set; }
}
