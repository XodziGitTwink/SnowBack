using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class JEmployeesSchedule
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public DateTime Date { get; set; }

    public int Employee { get; set; }

    public int Manager { get; set; }

    public string? Shift { get; set; }

    public string? Variant { get; set; }

    public string Type { get; set; } = null!;

    public virtual DStaff EmployeeNavigation { get; set; } = null!;
}
