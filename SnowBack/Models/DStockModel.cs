using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DStockModel : DStock
{
    public string FullInfo => $"{StockName} ({Id})";
}
