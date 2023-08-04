using System.ComponentModel.DataAnnotations;

namespace BioMedTracker.Repository.EFModels
{
    public partial class DrugIndication
    {
        [Key]
        public int RecordID { get; set; }
        public int DrugID { get; set; }
        public int IndicationID { get; set; }
        public int SubIndicationID { get; set; }
        public int SubSubIndicationID { get; set; }
        public string IndicationName { get; set; }
        public string SubIndicationName { get; set; }
        public string SubSubIndicationName { get; set; }
    }
}
