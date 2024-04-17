using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DInfraElementsField
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Typecode { get; set; }

    public DateTime? Dateon { get; set; }

    public string? Value { get; set; }
}
