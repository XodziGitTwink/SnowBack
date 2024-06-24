using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DRackModel : DRack
{
    public string FullInfo => $"{RackName} ({Id})";
}
