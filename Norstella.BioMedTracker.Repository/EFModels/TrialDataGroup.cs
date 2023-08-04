using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class TrialDataGroup
{
    public int TrialGroupId { get; set; }

    public int? TrialDataId { get; set; }

    public int? GroupId { get; set; }

    public string TreatDesc { get; set; }

    public int? SortOrder { get; set; }

    public virtual TrialDatum TrialData { get; set; }
}
