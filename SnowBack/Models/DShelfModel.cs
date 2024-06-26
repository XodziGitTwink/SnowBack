using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DShelfModel : DShelf
{
    public string FullInfo => $"{ShelfName} ({Id})";
}
