using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class DrugIndication
{
    public int RecordId { get; set; }

    public int? DrugId { get; set; }

    public int? IndicationId { get; set; }

    public int? SubIndicationId { get; set; }

    public int? SubSubIndicationId { get; set; }

    public virtual ICollection<DrugEvent> DrugEvents { get; set; } = new List<DrugEvent>();

    public virtual ICollection<Trial> Trials { get; set; } = new List<Trial>();
}
