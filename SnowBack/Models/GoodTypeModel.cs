using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class GoodTypeModel : DGoodsType
{
    public string FullName => $"{Name} ({Id})";
}
