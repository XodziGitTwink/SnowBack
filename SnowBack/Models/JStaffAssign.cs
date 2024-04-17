using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JStaffAssign
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public int Employee { get; set; }

    public int Position { get; set; }

    public DateOnly Hired { get; set; }

    public DateOnly? Fired { get; set; }
}
