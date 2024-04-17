using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JEmployeesMove
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public DateTime Started { get; set; }

    public int Vehicle { get; set; }

    public int Point { get; set; }

    public int UserWho { get; set; }
}
