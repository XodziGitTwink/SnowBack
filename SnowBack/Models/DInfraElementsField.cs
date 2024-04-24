using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DInfraElementsField
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public int? Type { get; set; }

    public DateTime? Dateon { get; set; }

    public string? Value { get; set; }

    public int? FieldType { get; set; }

    public virtual DDfieldsType? FieldTypeNavigation { get; set; }

    public virtual DInfraElementsType? TypeNavigation { get; set; }
}
