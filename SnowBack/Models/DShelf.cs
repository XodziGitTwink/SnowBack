using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DShelf
{
    public int Id { get; set; }

    public int RackId { get; set; }

    public string? ShelfName { get; set; }

    public string? ShelfDiscription { get; set; }

    public Guid? Guid { get; set; }
}
