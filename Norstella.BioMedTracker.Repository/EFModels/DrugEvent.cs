using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class DrugEvent
{
    public int RecordId { get; set; }

    public int? DrugId { get; set; }

    public int? IndicationId { get; set; }

    public int? EventTypeId { get; set; }

    public DateTime? EventDate { get; set; }

    public string TrialId { get; set; }

    public virtual EventType EventType { get; set; }

    public virtual DrugIndication Indication { get; set; }

    public virtual ICollection<TrialDatum> TrialData { get; set; } = new List<TrialDatum>();

    public virtual ICollection<TrialEvent> TrialEvents { get; set; } = new List<TrialEvent>();
}
