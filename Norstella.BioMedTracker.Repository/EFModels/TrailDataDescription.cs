using Microsoft.EntityFrameworkCore;

namespace BioMedTracker.Repository.EFModels
{
    [Keyless]
    public class TrailDataDescription
    {
        public int TrialDescID { get; set; }
        public string Description { get; set; }
    }
}
