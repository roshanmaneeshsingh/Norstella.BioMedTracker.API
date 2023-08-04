using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class SubSubIndication
{
    public int SubSubIndicationId { get; set; }

    public string SubSubIndicationName { get; set; }

    public int? SubIndicationId { get; set; }

    public int? IndicationId { get; set; }

    public virtual Indication Indication { get; set; }

    public virtual SubIndication SubIndication { get; set; }
}
