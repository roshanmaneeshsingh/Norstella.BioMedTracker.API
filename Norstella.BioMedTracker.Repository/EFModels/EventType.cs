using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class EventType
{
    public int EventTypeId { get; set; }

    public string EventType1 { get; set; }

    public virtual ICollection<DrugEvent> DrugEvents { get; set; } = new List<DrugEvent>();
}
