using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DDfieldsType
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<DInfraElementsField> DInfraElementsFields { get; set; } = new List<DInfraElementsField>();
}
