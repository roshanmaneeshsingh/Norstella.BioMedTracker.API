using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class TrialDataDesc
{
    public int TrialDescId { get; set; }

    public int? TrialDataId { get; set; }

    public string Description { get; set; }

    public int? EffectId { get; set; }

    public int? EndpointId { get; set; }

    public int? MeasureTypeId { get; set; }

    public object Grp1Measure { get; set; }

    public string Grp1Sign { get; set; }

    public object Grp1Pvalue { get; set; }

    public double? Grp1MeasureValue { get; set; }

    public object Grp2Measure { get; set; }

    public string Grp2Sign { get; set; }

    public object Grp2Pvalue { get; set; }

    public double? Grp2MeasureValue { get; set; }

    public object Grp3Measure { get; set; }

    public string Grp3Sign { get; set; }

    public object Grp3Pvalue { get; set; }

    public double? Grp3MeasureValue { get; set; }

    public object Grp4Measure { get; set; }

    public string Grp4Sign { get; set; }

    public object Grp4Pvalue { get; set; }

    public double? Grp4MeasureValue { get; set; }

    public object Grp5Measure { get; set; }

    public string Grp5Sign { get; set; }

    public object Grp5Pvalue { get; set; }

    public double? Grp5MeasureValue { get; set; }

    public object Grp6Measure { get; set; }

    public string Grp6Sign { get; set; }

    public object Grp6Pvalue { get; set; }

    public double? Grp6MeasureValue { get; set; }

    public int? SortOrder { get; set; }

    public virtual TrialDatum TrialData { get; set; }
}
