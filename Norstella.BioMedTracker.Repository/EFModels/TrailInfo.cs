using Microsoft.EntityFrameworkCore;
using System;

namespace BioMedTracker.Repository.EFModels
{
    [Keyless]
    public class TrailInfo
    {
        public int? TrialDataId { get; set; }
        public int? RecordID { get; set; }
        public string TrialName { get; set; }
        public string PrimaryId { get; set; }
        public string Pivotal { get; set; }
        public DateTime? EventDate { get; set; }

    }
}
