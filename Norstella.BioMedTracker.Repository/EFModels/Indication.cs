using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class Indication
{
    public int IndicationId { get; set; }

    public string IndicationName { get; set; }

    public virtual ICollection<SubSubIndication> SubSubIndications { get; set; } = new List<SubSubIndication>();
}
