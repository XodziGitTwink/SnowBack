using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DTmcTypeModel : DTmcType
{
    public string FullInfo => $"{Name} ({Id})";
}
