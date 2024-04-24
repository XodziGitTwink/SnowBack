using System;
using System.Collections.Generic;

namespace SnowBack.Models;

public partial class DInfraElementsType
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<DInfraElement> DInfraElements { get; set; } = new List<DInfraElement>();

    public virtual ICollection<DInfraElementsField> DInfraElementsFields { get; set; } = new List<DInfraElementsField>();

    public virtual ICollection<DInfraElementsFunction> DInfraElementsFunctions { get; set; } = new List<DInfraElementsFunction>();
}
