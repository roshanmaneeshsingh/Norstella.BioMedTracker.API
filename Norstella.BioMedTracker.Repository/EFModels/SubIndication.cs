using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class SubIndication
{
    public int SubIndicationId { get; set; }

    public string SubIndicationName { get; set; }

    public int? IndicationId { get; set; }

    public virtual ICollection<SubSubIndication> SubSubIndications { get; set; } = new List<SubSubIndication>();
}
