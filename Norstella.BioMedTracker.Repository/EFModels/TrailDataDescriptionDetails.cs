using Microsoft.EntityFrameworkCore;

namespace BioMedTracker.Repository.EFModels
{
    [Keyless]
    public class TrailDataDescriptionDetails
    {
        public string TrialName { get; set; }
        public string Description { get; set; }
        public string TreatDesc_O1 { get; set; }
        public string GroupType_O1 { get; set; }
        public int? Grp1Measure { get; set; }
        public string TreatDesc_O2 { get; set; }
        public string GroupType_O2 { get; set; }
        public int? Grp2Measure { get; set; }
        public string TreatDesc_O3 { get; set; }
        public string GroupType_O3 { get; set; }
        public int? Grp3Measure { get; set; }
        public string TreatDesc_O4 { get; set; }
        public string GroupType_O4 { get; set; }
        public int? Grp4Measure { get; set; }
    }
}
