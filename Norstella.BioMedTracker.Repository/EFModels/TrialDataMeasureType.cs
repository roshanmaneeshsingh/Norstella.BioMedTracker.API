using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class TrialDataMeasureType
{
    public int MeasureTypeId { get; set; }

    public string MeasureName { get; set; }
}
