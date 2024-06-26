using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DTmcFunctionModel : DTmcFunction
{
    public string FullInfo => $"{Name} ({Id})";
}
