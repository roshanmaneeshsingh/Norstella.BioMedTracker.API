using Microsoft.EntityFrameworkCore;

namespace BioMedTracker.Repository.EFModels
{
    [Keyless]
    public class DrugsIndicationWithSubIndication
    {
        public int IndicationID { get; set; }
        public string IndicationName { get; set; }
        public int SubIndicationID { get; set; }
        public string SubIndicationName { get; set; }
        public int SubSubIndicationID { get; set; }
        public string SubSubIndicationName { get; set; }
    }
}
