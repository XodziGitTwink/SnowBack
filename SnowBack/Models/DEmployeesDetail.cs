using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DEmployeesDetail
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public string Sname { get; set; } = null!;

    public string? Mname { get; set; }

    public string? Shortname { get; set; }

    public DateOnly? Birth { get; set; }

    public string? Code { get; set; }

    public string? Phone { get; set; }

    public string? Cloth { get; set; }

    public string? Shoes { get; set; }

    public string? Height { get; set; }

    public string? Breast { get; set; }

    public string? Waist { get; set; }

    public string? Hand { get; set; }

    public string? Head { get; set; }

    public string? Step { get; set; }

    public string? Gloves { get; set; }
}
