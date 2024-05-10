using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DStaff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surename { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Code { get; set; }

    public string? CallId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }
}
