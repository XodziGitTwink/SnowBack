using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class Shift
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Duration { get; set; }

    public virtual ICollection<JEmployeesSchedule> JEmployeesSchedules { get; set; } = new List<JEmployeesSchedule>();
}
