using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DGoodsInfraRelation
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int Good { get; set; }

    public int Element { get; set; }
}
