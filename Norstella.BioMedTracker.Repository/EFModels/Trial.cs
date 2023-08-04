using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class Trial
{
    public int TrialId { get; set; }

    public int? IndicationRecId { get; set; }

    public string TrialName { get; set; }

    public string Pivotal { get; set; }

    public DateTime? InitiationDate { get; set; }

    public string PrimaryId { get; set; }

    public int? TrialTroveId { get; set; }

    public virtual DrugIndication IndicationRec { get; set; }

    public virtual ICollection<TrialEvent> TrialEvents { get; set; } = new List<TrialEvent>();
}
