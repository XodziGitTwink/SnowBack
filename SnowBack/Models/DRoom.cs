using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DRoom
{
    public int Id { get; set; }

    public int StockId { get; set; }

    public string? RoomName { get; set; }

    public string? RoomDescription { get; set; }

    public Guid? Guid { get; set; }
}
