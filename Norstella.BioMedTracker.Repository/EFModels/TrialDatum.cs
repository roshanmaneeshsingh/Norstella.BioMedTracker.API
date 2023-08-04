using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class TrialDatum
{
    public int TrialDataId { get; set; }

    public int? EventId { get; set; }

    public int? Grp1Id { get; set; }

    public int? Grp2Id { get; set; }

    public int? Grp3Id { get; set; }

    public int? Grp4Id { get; set; }

    public int? Grp5Id { get; set; }

    public int? Grp6Id { get; set; }

    public virtual DrugEvent Event { get; set; }

    public virtual ICollection<TrialDataDesc> TrialDataDescs { get; set; } = new List<TrialDataDesc>();

    public virtual ICollection<TrialDataGroup> TrialDataGroups { get; set; } = new List<TrialDataGroup>();
}
