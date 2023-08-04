using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class TrialEvent
{
    public int? EventId { get; set; }

    public int? TrialId { get; set; }

    public int TrialEventsId { get; set; }

    public virtual DrugEvent Event { get; set; }

    public virtual Trial Trial { get; set; }
}
