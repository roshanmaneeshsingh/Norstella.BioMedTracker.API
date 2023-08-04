using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class TrialDataEffectType
{
    public int EffectId { get; set; }

    public string EffectName { get; set; }

    public int? EffectGroupTypeId { get; set; }
}
