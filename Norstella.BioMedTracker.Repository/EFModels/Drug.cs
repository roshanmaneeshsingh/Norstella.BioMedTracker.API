using System;
using System.Collections.Generic;

namespace BioMedTracker.Repository.EFModels;

public partial class Drug
{
    public int DrugId { get; set; }

    public string DrugName { get; set; }

    public string BrandName { get; set; }

    public string GenericName { get; set; }
}
